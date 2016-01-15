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
open OsmSharp.Android.UI
open OsmSharp.UI.Map
open OsmSharp.UI.Map.Layers
open OsmSharp.Math.Geo
open OsmSharp.Units.Angle

[<Activity (Label = "OnMapActivity")>]
type OnMapActivity () =
  inherit Activity()

  override this.OnCreate(bundle) =
    base.OnCreate (bundle)
    // Create your application here
    this.RequestWindowFeature(global.Android.Views.WindowFeatures.NoTitle) |> ignore
    
    let mutable map = new Map()
    map.AddLayer(new LayerTile("http://to.be.added.ok", 160))

    let mutable mvs = new MapViewSurface(this)
    let mutable mv = new MapView(this, mvs)

    mv.Map <- map
    mv.MapMaxZoomLevel <- Nullable 18.0f
    mv.MapMinZoomLevel <- Nullable 0.0f
    mv.MapTilt <- Degree 0.0
    mv.MapCenter <- new GeoCoordinate(-6.21754,106.6586053)
    mv.MapZoom <- 12.0f

    this.SetContentView(mv)