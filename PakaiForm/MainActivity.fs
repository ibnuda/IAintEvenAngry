namespace PakaiForm

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open Xamarin.Forms

[<Activity (Label = "PakaiForm", MainLauncher = true)>]
type MainActivity () =
    inherit Activity ()

    let mutable count:int = 1

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        // Set our view from the "main" layout resource

