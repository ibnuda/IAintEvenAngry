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

[<Activity (Label = "MapActivity")>]
type MapActivity () =
    inherit Activity()

    override this.OnCreate(bundle) =
        Native.Initialize ()
        OsmSharp.Logging.Log.Enable ()
        OsmSharp.Logging.Log.RegisterListener(new OsmSharp.Android.UI.Log.LogTraceListener())
        base.OnCreate (bundle)

        this.SetContentView(Resource_Layout.Map)

        let layout = new LinearLayout(this)
        layout.Orientation = Orientation.Vertical |> ignore

        let myButtTiles = new Button(this)
        myButtTiles.Text <- "Offline map."
        myButtTiles.Click.Add(fun args ->
            this.StartActivity(typeof<OffTilesActivity>)
        )

        let tilesButton = new Button(this)
        tilesButton.Text <- "Online Map"
        tilesButton.Click.Add(fun args ->
            this.StartActivity(typeof<OnMapActivity>)
        )

        let vectorButton = new Button(this)
        vectorButton.Text <- "Vektor"
        vectorButton.Click.Add(fun args ->
            this.StartActivity(typeof<VectorMapActivity>)
        )

    override this.OnBackPressed () = this.MoveTaskToBack (true) |> ignore
