module Client

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props
open Fetch.Types
open Thoth.Fetch
open Fulma
open Thoth.Json

open Schema
open FableHelpers

type Screen =
    | Home
    | LoadScreen
    | CreateScreen
    | ConfirmWipe

// The model holds data that you want to keep track of while the application is running
// in this case, we are keeping track of a counter
// we mark it as optional, because initially it will not be available from the client
// the initial value will be requested from server
type Model = { Screen:Screen; PlayerProperties:PlayerProperties option}

// The Msg type defines what events/actions can occur while the application is running
// the state of the application changes *only* in reaction to these events
type Msg =
    | BattleMsg of Js.Battle.Msg
    | NewGame
    // handles the load button and load game buttons
    | Load of int option
    | CancelLoad
    | ClearSaves

// let initialCounter () = Fetch.fetchAs<unit, Counter> "/api/init"

// defines the initial state and initial command (= side-effect) of the application
let init () : Model * Cmd<Msg> =
    let initialModel = { Screen=Home; PlayerProperties = None }
    initialModel, Cmd.none

// The update function computes the next state of the application based on the current state and the incoming events/messages
// It can also run side-effects (encoded as commands) like calling the server via Http.
// these commands in turn, can dispatch messages to which the update function will react.
let update (msg : Msg) (currentModel : Model) : Model * Cmd<Msg> =
    match currentModel, msg with
    | _ -> currentModel, Cmd.none

let landingScreen (dispatch : Msg -> unit) =
    div [Id "startingScreen"; Style [Display DisplayOptions.Block]][
        div [Class "gameLogo"; Id "gameLogo"][
            row[
                div[Class "col-xs-12"][]
            ]
        ]
        div [Class "buttonDiv"; Id "buttonDiv"][
            row[
                div[Class "col-xs-6 col-xs-3"][
                    div[Class "btn-group-vertical";Role "group";AriaLabel "New game, load game"][
                        let mbutton msg (text:string) =
                            button[Style[MarginBottom "5px"]; Class"btn btn-default border"; OnClick (fun _ -> msg |> dispatch)][
                            unbox text

                        ]
                        mbutton Msg.NewGame "New Game"
                        mbutton (Msg.Load None) "Load"
                        mbutton (Msg.ClearSaves) "Reset all saves"
                    ]
                ]
            ]
        ]
    ]
let loadOrCreateScreen isCreate (dispatch : Msg -> unit) =
    div [Class "raceCreation"; Id "raceCreation"][

    ]


let view (model : Model) (dispatch : Msg -> unit) =
    let bMsg: Js.Battle.Msg -> unit =
        fun msg ->
            msg
            |> Msg.BattleMsg
            |> dispatch
    div []
        [   Navbar.navbar [ Navbar.Color IsPrimary ]
                [ Navbar.Item.div [ ]
                    [ Heading.h2 [ ]
                        [ str "SAFE Template" ] ] ]

            Container.container []
                [
                    row[
                        match model.PlayerProperties with
                        | Some pp ->
                            yield Js.Battle.view pp { Monster={Monster.Empty with Name="AlphaStalker"}} bMsg
                        | None ->
                            yield landingScreen dispatch
                    ]

                ]

            Footer.footer [ ]
                [ Content.content [ Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
                    [
                        ul[][
                            li[][ a[Href "https://github.com/tarnos12/project"][ unbox "Original source"] ]
                            li[][ a[Href "https://tarnos12.github.io/project/"][ unbox "Original game"]]
                            li[][ a[Href "https://github.com/ImaginaryDevelopment/Fable.Static"][ unbox "Fable Conversion template"]]
                        ]
                    ] ] ]

#if DEBUG
open Elmish.Debug
open Elmish.HMR
#endif

Program.mkProgram init update view
#if DEBUG
|> Program.withConsoleTrace
#endif
|> Program.withReactBatched "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
