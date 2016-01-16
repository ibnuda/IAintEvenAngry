namespace IAintEvenAngry

open System
open System.Collections.Generic
open System.Linq
open System.Text

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open Xamarin.Forms.Platform.Android
open Android.Content.PM

[<Activity (Label = "PakaiXamFormActivity")>]
type PakaiXamFormActivity () =
    inherit global.Xamarin.Forms.Platform.Android.FormsApplicationActivity()

    override this.OnCreate(bundle) =
        base.OnCreate (bundle)
        global.Xamarin.Forms.Forms.Init (this, bundle)
        global.Xamarin.FormsMaps.Init (this, bundle)

        // this.LoadApplication (new App ())


