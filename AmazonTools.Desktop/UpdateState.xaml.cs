using System;
using System.Linq;
using System.Windows;
using AmazonTools.Desktop.Common;
using AmazonTools.Model._Admin;
using HandyControl.Controls;
using Microsoft.EntityFrameworkCore;

namespace AmazonTools.Desktop
{
    /// <summary>
    /// UpdateState.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateState
    {
        private AppDbContext db = new AppDbContext();
        private AmazonSiteInfo entity = new AmazonSiteInfo();
        public UpdateState(AmazonSiteInfo siteInfo)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            entity = siteInfo;
            var zhuangTaiId = db.DicDefs.First(x=>x.DicName=="站点状态");
            db.DicFields.Where(x => x.DicDefId == zhuangTaiId.ID).ToList().ForEach(x =>
            {

                cb_State.Items.Add(x.DicFieldDes);
            });

            cb_State.SelectedItem = siteInfo.AmazonState.DicFieldDes;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {

            // 最佳实践实现
            var stateName = cb_State.Text;

            // 获取状态ID（不跟踪查询）
            var stateId = db.DicFields.AsNoTracking()
    .Where(f => f.DicDef.DicName == "站点状态" && f.DicFieldDes == stateName)
    .Select(f => f.ID)
    .FirstOrDefault();

            if (stateId == default)
            {
                Growl.ErrorGlobal($"找不到对应的状态: {stateName}");
                return;
            }

            // 只更新外键ID
            entity.AmazonStateId = stateId;
            entity.UpdateBy = HttpClientHelper.account;
            entity.UpdateTime = DateTime.Now;
            entity.AmazonUser.UpdateBy = HttpClientHelper.account;
            entity.AmazonUser.UpdateTime = DateTime.Now;
            // 显式标记所有需要更新的字段
            db.Entry(entity).Property(x => x.AmazonStateId).IsModified = true;
            db.Entry(entity).Property(x => x.UpdateBy).IsModified = true;
            db.Entry(entity).Property(x => x.UpdateTime).IsModified = true;
            db.Entry(entity.AmazonUser).Property(x => x.UpdateBy).IsModified = true;
            db.Entry(entity.AmazonUser).Property(x => x.UpdateTime).IsModified = true;
            if (db.SaveChanges() > 0)
            {

                Growl.SuccessGlobal($"客户:{entity.AmazonUser.FaUserNameCn},修改状态为:{stateName}！！！");
                this.Close();
            }
            else
            {
                Growl.ErrorGlobal($"客户:{entity.AmazonUser.FaUserNameCn} 状态修改失败！！！");
            }
        }
    }
}
