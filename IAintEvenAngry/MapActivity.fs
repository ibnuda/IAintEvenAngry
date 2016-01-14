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
        layout.Orientation = Orientation.Vertical

        let myButtTiles = new Button(this)
        myButtTiles.Text <- "Offline map."

    override this.OnBackPressed () = this.MoveTaskToBack (true) |> ignore
