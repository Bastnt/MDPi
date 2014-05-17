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

namespace MDPi.Droid.Views
{
    [Activity(Label = "View for FirstViewModel", Theme = "@android:style/Theme.Holo.Light")]
	public class FirstView : MvxFragmentActivity
    {
        // PagerSlidingTabStrip and ViewPager initialisation
        private ViewPager viewPager;
        private PagerSlidingTabStrip.PagerSlidingTabStrip pageIndicator;
        private MvxViewPagerFragmentAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.FirstView);

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
    }
}