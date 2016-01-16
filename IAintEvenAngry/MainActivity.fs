namespace IAintEvenAngry

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget

[<Activity (Label = "IAintEvenAngry", MainLauncher = true)>]
type MainActivity () =
    inherit Activity ()

    let mutable count:int = 1

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        // Set our view from the "main" layout resource
        this.SetContentView (Resource_Layout.Main)

        let username = this.FindViewById<EditText>(Resource_Id.editTextUsername)
        let password = this.FindViewById<EditText>(Resource_Id.editTextPassword)
        let btnLogin = this.FindViewById<Button>(Resource_Id.buttonLogin)

        btnLogin.Click.Add(fun args ->
            match this.Authenticate username.Text password.Text with
            | true ->
                let i = new Intent(this, typeof<MapActivity>)
                this.Finish()
                this.StartActivity (i) |> ignore
            | false ->
                let i = new Intent(this, typeof<MainActivity>)
                this.Finish()
                this.StartActivity (i) |> ignore
        )

    member this.Authenticate (username: string) (password: string) =
        // Somebody, please create a decent server.
        username.Equals("ibnu") && password.Equals("asdf")