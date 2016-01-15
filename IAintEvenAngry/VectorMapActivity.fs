namespace IAintEvenAngry

open System
open System.Collections.Generic
open System.Linq
open System.Text
open System.Reflection

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget
open OsmSharp.Android.UI
open OsmSharp.UI.Map
open OsmSharp.UI.Map.Layers
open OsmSharp.UI.Renderer.Scene
open OsmSharp.Math.Geo

[<Activity (Label = "VectorMapActivity")>]
type VectorMapActivity () =
    inherit Activity()

    override this.OnCreate(bundle) =
        base.OnCreate (bundle)
    // Create your application here
        this.RequestWindowFeature(global.Android.Views.WindowFeatures.NoTitle) |> ignore

        let mutable map = new Map()
        let mutable screenStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(@"default.map")

        let mutable mvs = new MapViewSurface(this)
        let mutable mv = new MapView(this, mvs)
        mv.Map <- map
        mv.MapMaxZoomLevel <- Nullable 17.0f
        mv.MapMinZoomLevel <- Nullable 12.0f
        mv.MapTilt <- OsmSharp.Units.Angle.Degree(0.0)
        mv.MapCenter <- new GeoCoordinate(-6.224454, 106.653069)
        mv.MapZoom <- 16.0f
        mv.MapAllowTilt <- false

        this.SetContentView(mv)
