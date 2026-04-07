using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using AmazonTools.Desktop.Common;
using HandyControl.Controls;
using Microsoft.EntityFrameworkCore;

namespace AmazonTools.Desktop
{
    /// <summary>
    /// SiteInfo.xaml 的交互逻辑
    /// </summary>
    public partial class SiteInfo
    {
        private AppDbContext db = new AppDbContext();
        public SiteInfo()
        {
            InitializeComponent();
            cb_zhandian.Items.Add("");
            cb_zhuangtai.Items.Add("");
            var zhandianid = db.DicDefs.First(x => x.DicName == "站点");
            db.DicFields.Where(x => x.DicDefId == zhandianid.ID).ToList().ForEach(x =>
            {

                cb_zhandian.Items.Add(x.DicFieldDes);
            });

            var zhuangTaiId = db.DicDefs.First(x => x.DicName == "站点状态");
            db.DicFields.Where(x => x.DicDefId == zhuangTaiId.ID).ToList().ForEach(x =>
            {

                cb_zhuangtai.Items.Add(x.DicFieldDes);
            });
            pg_page.PageIndex = 1;
            pg_page.DataCountPerPage = 200;
            var siteCount = db.AmazonSiteInfos.Count();
            pg_page.MaxPageCount = (siteCount / 200) + 1;
            dg_filter.ItemsSource = AmazonSiteInfos("", "", "", "", pg_page.PageIndex, 200);
        }

        private List<Model._Admin.AmazonSiteInfo> AmazonSiteInfos(string userName, string site, string state, string mail, int pageNumber, int pageSize)
        {

            var mode = db.AmazonSiteInfos.AsQueryable().AsNoTracking();


            if (site != "")
            {

                mode = mode.Where(x => x.SiteName.DicFieldDes == site);
            }
            if (state != "")
            {

                mode = mode.Where(x => x.AmazonState.DicFieldDes == state);
            }
            if (userName != "")
            {

                mode = mode.Where(x => x.AmazonUser.FaUserNameCn.Contains(userName));
            }
            if (mail != "")
            {
                mode = mode.Where(x => x.Mail == mail);
            }

            var sitelist = mode.OrderByDescending(x => x.CreateTime)
                  .Skip((pageNumber-1)*pageSize)
                  .Take(pageSize)
                  .ToList();

            return sitelist;
        }
        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            AddAmazonUserInfo addAmazonUserInfo = new AddAmazonUserInfo();
            if (!(bool)addAmazonUserInfo.ShowDialog())
            {
                dg_filter.ItemsSource = null;
                dg_filter.ItemsSource = AmazonSiteInfos(tb_UserName.Text.Trim(), cb_zhandian.Text, cb_zhuangtai.Text, tb_Mail.Text.Trim(), 1, pg_page.PageIndex);
            }
        }

        private void Button_Click_Select(object sender, RoutedEventArgs e)
        {
            dg_filter.ItemsSource = null;
            dg_filter.ItemsSource = AmazonSiteInfos(tb_UserName.Text.Trim(), cb_zhandian.Text, cb_zhuangtai.Text, tb_Mail.Text.Trim(), pg_page.PageIndex, 200);
        }

        private void Button_Click_UpdateState(object sender, RoutedEventArgs e)
        {
            var siteMode = dg_filter.SelectedItem as Model._Admin.AmazonSiteInfo;
            if (siteMode == null)
            {
                Growl.InfoGlobal("请先选择一行数据");
                return;
            }
            UpdateState updateState = new UpdateState(siteMode);
            if (!(bool)updateState.ShowDialog())
            {
                dg_filter.ItemsSource = null;
                dg_filter.ItemsSource = AmazonSiteInfos(tb_UserName.Text.Trim(), cb_zhandian.Text, cb_zhuangtai.Text, tb_Mail.Text.Trim(), pg_page.PageIndex, 200);
            }

        }

        private void Button_Click_ValidatorWindows(object sender, RoutedEventArgs e)
        {
            var siteMode = dg_filter.SelectedItem as Model._Admin.AmazonSiteInfo;
            if (siteMode == null)
            {
                Growl.InfoGlobal("请先选择一行数据");
                return;
            }
            ValidatorWindows ValidatorWindows = new ValidatorWindows(siteMode);
            if (!(bool)ValidatorWindows.ShowDialog())
            {
                dg_filter.ItemsSource = null;
                dg_filter.ItemsSource = AmazonSiteInfos(tb_UserName.Text.Trim(), cb_zhandian.Text, cb_zhuangtai.Text, tb_Mail.Text.Trim(), pg_page.PageIndex, 200);
            }
        }

        private void Button_Click_admin(object sender, RoutedEventArgs e)
        {
            if (HttpClientHelper.account != "admin")
            {
                Growl.ErrorGlobal("干活就干活,你打包材料想干嘛?");
                return;
            }
            var siteMode = dg_filter.SelectedItem as Model._Admin.AmazonSiteInfo;
            if (siteMode == null)
            {
                Growl.InfoGlobal("请先选择一行数据");
                return;
            }
            EndPackaged endPackaged = new EndPackaged(siteMode);
            if (!(bool)endPackaged.ShowDialog())
            {
                dg_filter.ItemsSource = null;
                dg_filter.ItemsSource = AmazonSiteInfos(tb_UserName.Text.Trim(), cb_zhandian.Text, cb_zhuangtai.Text, tb_Mail.Text.Trim(), pg_page.PageIndex, 200);
            }
        }

        private void pg_page_PageUpdated(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            dg_filter.ItemsSource = null;
            dg_filter.ItemsSource = AmazonSiteInfos(tb_UserName.Text.Trim(), cb_zhandian.Text, cb_zhuangtai.Text, tb_Mail.Text.Trim(), pg_page.PageIndex, 200);
        }
    }
}
