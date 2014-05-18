using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using MDPi.Core.ViewModels;

namespace MDPi.Droid.Views
{
    public class AddTorrentView : MvxDialogFragment
    {
        public override Dialog OnCreateDialog(Bundle savedState)
        {
            base.EnsureBindingContextSet(savedState);

            var view = this.BindingInflate(Resource.Layout.AddTorrentView, null);
            var editTextAnimeName = view.FindViewById<EditText>(Resource.Id.editText_AnimeName);
            editTextAnimeName.TextChanged += (o, e) => 
                {
                    ((AddTorrentViewModel)ViewModel).Name = e.Text.ToString();
                };

            var dialog = new AlertDialog.Builder(Activity);
            dialog.SetTitle("Add a new torrent");
            dialog.SetView(view);
            dialog.SetNegativeButton("Cancel", (s, a) => { });
            dialog.SetPositiveButton("OK", (s, a) =>
                {
                });
            return dialog.Create();
        }
    }
}