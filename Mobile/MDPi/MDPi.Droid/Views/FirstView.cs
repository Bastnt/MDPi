using System.Text;
using System;
using System.ComponentModel;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Views;
using Android.Support.V4.View;
using Android.Graphics;

using Cirrious.MvvmCross.Droid.Fragging;

using MDPi.Droid.Adapters;
using MDPi.Core.ViewModels;
using Cirrious.CrossCore;
using MDPi.Core.Services.ServerInteractionServices;
using Android.Graphics.Drawables;
using Android.Support.V4.Widget;
using Android.Content.PM;
using System.Windows.Input;

namespace MDPi.Droid.Views
{
    [Activity(Label = "MDPi", Theme = "@android:style/Theme.Holo.Light", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.KeyboardHidden)]
	public class FirstView : MvxFragmentActivity
    {
        private const string TorrentDialogTagName = "Add Torrent";

        // PagerSlidingTabStrip and ViewPager initialisation
        private ViewPager viewPager;
        private PagerSlidingTabStrip.PagerSlidingTabStrip pageIndicator;
        private MvxViewPagerFragmentAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.FirstView);

            var existingDialog = (AddTorrentView)SupportFragmentManager.FindFragmentByTag(TorrentDialogTagName);
            if (existingDialog != null)
            {
                existingDialog.ViewModel = ((FirstViewModel)ViewModel).AddTorrentViewModel;
            }

            // PagerSlidingTabStrip and ViewPager initialisation
			var fragments = new List<MvxViewPagerFragmentAdapter.FragmentInfo> {
                new MvxViewPagerFragmentAdapter.FragmentInfo
				{
					FragmentType = typeof(TorrentsView),
					Title = "My tracked animes",
					ViewModel = ((FirstViewModel)ViewModel).TorrentsViewModel,
				},
                new MvxViewPagerFragmentAdapter.FragmentInfo
				{
					FragmentType = typeof(BrowseView),
					Title = "All tracked animes",
					ViewModel = ((FirstViewModel)ViewModel).BrowseViewModel,
				},
			};


			viewPager = FindViewById<ViewPager>(Resource.Id.pager);
			pageIndicator = FindViewById<PagerSlidingTabStrip.PagerSlidingTabStrip>(Resource.Id.indicator);
			adapter = new MvxViewPagerFragmentAdapter(this, SupportFragmentManager, fragments);

            // Set the pager with an adapter:
            viewPager.Adapter = adapter;

            //Set the pager to the tabs control:
            pageIndicator.SetViewPager(viewPager);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.ActionBar, menu);

            var addTorrentMenuItem = menu.FindItem(Resource.Id.addTorrentMenuItem);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {

                case Resource.Id.addTorrentMenuItem:
                    ShowDialog();
                    return true;

                case Resource.Id.editPreferencesMenuItem:
                    ((FirstViewModel)ViewModel).SettingsCommand.Execute(string.Empty);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public void ShowDialog()
        {
            var dialog = new AddTorrentView();
            dialog.ViewModel = ((FirstViewModel)ViewModel).AddTorrentViewModel;
            dialog.Show(SupportFragmentManager, TorrentDialogTagName);
        }
    }
}