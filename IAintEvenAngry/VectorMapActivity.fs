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

[<Activity (Label = "VectorMapActivity")>]
type VectorMapActivity () =
  inherit Activity()

  override this.OnCreate(bundle) =
    base.OnCreate (bundle)
    // Create your application here

