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
    | RaceSelection

// The model holds data that you want to keep track of while the application is running
// in this case, we are keeping track of a counter
// we mark it as optional, because initially it will not be available from the client
// the initial value will be requested from server
type Model = { Screen:Screen; Slot:int option; PlayerProperties:PlayerProperties option}
    with
        static member Empty = {Screen = Home; Slot = None; PlayerProperties = None}

// The Msg type defines what events/actions can occur while the application is running
// the state of the application changes *only* in reaction to these events
type Msg =
    | BattleMsg of Js.Battle.Msg
    | GoHome
    | NewGame of int option
    // handles the load button and load game buttons
    | Load of int option
    | CancelLoad
    | ClearSaves

// let initialCounter () = Fetch.fetchAs<unit, Counter> "/api/init"

// defines the initial state and initial command (= side-effect) of the application
let init () : Model * Cmd<Msg> =
    let initialModel = Model.Empty
    initialModel, Cmd.none

// The update function computes the next state of the application based on the current state and the incoming events/messages
// It can also run side-effects (encoded as commands) like calling the server via Http.
// these commands in turn, can dispatch messages to which the update function will react.
let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
    match model, msg with
    | _, Msg.NewGame None -> {model with Screen = CreateScreen}, Cmd.none
    | _, Msg.NewGame (Some i) -> {model with Screen = RaceSelection;Slot=Some i}, Cmd.none
    | _ -> model, Cmd.none

let mbutton dispatch msg (text:string) =
    button[ Style[MarginBottom "5px"]
            Class"btn btn-default border"
            OnClick (fun _ -> msg |> dispatch)][
    unbox text
            ]

let landingScreen (dispatch : Msg -> unit) =
    div [Id "startingScreen"; Style [Display DisplayOptions.Block]][
        div [Class "buttonDiv"; Id "buttonDiv"][
            row[
                div[Class "col-xs-6 col-xs-3"][
                    div[Class "btn-group-vertical";Role "group";AriaLabel "New game, load game"][

                        mbutton dispatch (Msg.NewGame None) "New Game"
                        mbutton dispatch (Msg.Load None) "Load"
                        mbutton dispatch (Msg.ClearSaves) "Reset all saves"
                    ]
                    button [
                        Class "btn btn-default border startBackButtonMargin"
                        OnClick (fun _ -> Msg.GoHome |> dispatch)][unbox "Go Back"]
                ]
            ]
        ]
    ]

let loadOrCreateScreen isCreate (dispatch : Msg -> unit) =
    printfn "Doing load or create screen!"
    let inline mbutton x = mbutton dispatch x
    let gameText = if isCreate then sprintf "New Game %i" else sprintf "Load Game %i"
    let gameMsg = Some >> if isCreate then Msg.NewGame else Msg.Load
    div [Class "raceCreation"; Id "raceCreation"][
        row [
            div [Class "col-xs-12 newGameButton"][
                div [Class "btn-group-vertical"; Role "group"; AriaLabel "New game, load game"][
                    // TODO: show any current save info next to buttons
                    // mbutton (Msg.NewGame <| Some 0) "New Game 1"
                    mbutton (gameMsg 0) (gameText 1)
                    mbutton (gameMsg 1) (gameText 2)
                    mbutton (gameMsg 2) (gameText 3)
                    mbutton (gameMsg 3) (gameText 4)
                ]

            ]
        ]
    ]
let navbar = Navbar.navbar [ Navbar.Color IsPrimary ]
                [ Navbar.Item.div [ ]
                    [ Heading.h2 [ ][
                        div [Class "gameLogo"; Id "gameLogo";Style [MinHeight "250px";MinWidth "350px"]][]
                        ] ]
                ]

let view (model : Model) (dispatch : Msg -> unit) =
    let bMsg: Js.Battle.Msg -> unit =
        fun msg ->
            msg
            |> Msg.BattleMsg
            |> dispatch
    div []
        [
            navbar
            Container.container []
                [
                    row[
                        match model.PlayerProperties with
                        | Some pp ->
                            yield Js.Battle.view pp { Monster={Monster.Empty with Name="AlphaStalker"}} bMsg
                        | None ->
                            match model.Screen with
                            | Home -> yield landingScreen dispatch
                            | CreateScreen -> yield loadOrCreateScreen true dispatch
                            | LoadScreen -> yield loadOrCreateScreen false dispatch

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
