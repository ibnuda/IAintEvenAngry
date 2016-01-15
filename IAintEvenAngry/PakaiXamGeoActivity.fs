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
open Plugin.Geolocator

[<Activity (Label = "PakaiXamGeoActivity")>]
type PakaiXamGeoActivity () =
  inherit Activity()

  override this.OnCreate(bundle) =
    base.OnCreate (bundle)

    this.SetContentView(Resource_Layout.XamPlug)

    let locator: Abstractions.IGeolocator = CrossGeolocator.Current
    locator.DesiredAccuracy <- 50.0
    // let! posisi = await locator.GetPositionAsync ()

    let tvS = this.FindViewById<TextView>(Resource_Id.textViewStatus)
    let tvLat = this.FindViewById<TextView>(Resource_Id.textViewLatitude)
    let tvLong = this.FindViewById<TextView>(Resource_Id.textViewLongitude)
    let buttCek = this.FindViewById<Button>(Resource_Id.buttonCekPosisi)

    buttCek.Click.Add(fun args ->
        printfn "go go fuck yourself"
    )
