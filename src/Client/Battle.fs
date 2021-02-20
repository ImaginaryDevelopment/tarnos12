module Js.Battle
open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props

open Schema

type Model = { Monster:Monster}

type Msg =
    | Increment
    | Decrement
    | InitialCountLoaded

let init () : Model * Cmd<Msg> =
    let initialModel = { Monster = Monster.Empty}
    initialModel, Cmd.none

let update (msg : Msg) (currentModel : Model) : Model * Cmd<Msg> =
    currentModel, Cmd.none

let playerSpellDiv weaponOpt =
    let empty = div [Class "c3"] [unbox <| "Unlock some skills first! Using a weapon, will level up your proficiency, and unlock skills with it." ]
    match weaponOpt with
    | None -> empty
    | Some weapon ->
        empty

let startBattle playerProperties model =
    // let monsterStats = monsterList.[monster]
    let image = playerProperties.RaceAge + playerProperties.RaceImage
    [
        div [Class "row"][ // progress bar, player image, monster image, animations
            div[Id "monsterImage"; Class "col-xs-12 c3"][
                div[Class "progress"; Style [Width "50%";MarginLeft "25%"]][
                    div[    Style [Width "100%"]; AriaValuemax 100.; AriaValuemin 0.; AriaValuenow 60.
                            Role "progress-bar"; Id ("monster.name+1")][
                        span [Style [FontSize "13px"]][unbox <| sprintf "%A HP" model.Monster.Hp]
                    ]
                ]
                img [   Src <| sprintf "images/monsters/%s.png" model.Monster.Name;
                        Style [Position PositionOptions.Absolute;  Left "45%"; Top "50%"]]
            ]
            div[][]
        ]
        div [Class "row"] [
            div[Id "battleButtons"; Class "col-xs-12 c3"][
                // added later
            ]
        ]
        div [Class "row"] [
            div[Id "spellButtons"; Class "col-xs-4 col-xs-offset-4"][
                // added later
            ]
            div[Class "col-xs-10 col-xs-offset-1"][
                div[Class "collapse in"; Id "spellCollapse"; AriaExpanded true][]
            ]
        ]
    ]

let view playerProperties (model : Model) (dispatch : Msg -> unit) =
    div [] [
        yield! startBattle playerProperties model
    ]