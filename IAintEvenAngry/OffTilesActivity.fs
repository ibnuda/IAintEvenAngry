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
open OsmSharp.Android.UI.Data.SQLite
open OsmSharp.UI.Map.Layers
open System.Reflection
open OsmSharp.Math.Geo

[<Activity (Label = "Offline Tiles Activity")>]
type OffTilesActivity () =
    inherit Activity() 

    let mutable mapView: MapView = new MapView(null, null)

    override this.OnCreate(bundle) =
        base.OnCreate (bundle)
        // Create your application here
        this.RequestWindowFeature(global.Android.Views.WindowFeatures.NoTitle) |> ignore

        let mutable map = new Map()
        map.AddLayer(new LayerMBTile(SQLiteConnection.CreateFrom(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"IAintEvenAngry.kempen.mbtiles"), "map")))

        let mutable mapViewSurface = new MapViewSurface(this)
        // let mutable mapView = new MapView(this, mapViewSurface)
        mapView.Map <- map
        mapView.MapMaxZoomLevel <- Nullable 17.0f
        mapView.MapMinZoomLevel <- Nullable 12.0f
        mapView.MapTilt <- OsmSharp.Units.Angle.Degree(0.0)
        mapView.MapCenter <- new GeoCoordinate(51.26361, 4.786209)
        mapView.MapZoom <- 16.0f
        mapView.MapAllowTilt <- false

        this.SetContentView(mapView)

    override this.OnDestroy () =
        base.OnDestroy()