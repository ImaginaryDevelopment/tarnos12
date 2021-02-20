module Creation


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

type Model = { Age:Age }
    with
        static member Empty = {Age=Age.MiddleAge}

type ParentMsg =
    | RaceSelection of CharacterRaceType
    | CancelRace

type Msg =
    | AgeSelection of Age
    // message to parent for handling
    | ParentMsg of ParentMsg


let init () : Model * Cmd<Msg> =
    let initialModel = Model.Empty
    initialModel, Cmd.none

// The update function computes the next state of the application based on the current state and the incoming events/messages
// It can also run side-effects (encoded as commands) like calling the server via Http.
// these commands in turn, can dispatch messages to which the update function will react.
let update (msg : Msg) (model : Model) : Model * Cmd<Msg> =
    match model, msg with
    | _ -> model, Cmd.none

let view (model : Model) (dispatch : Msg -> unit) =
    let raceClick x = OnClick (fun _ -> Msg.ParentMsg (ParentMsg.RaceSelection x) |> dispatch)
    let createAgeBlip x =
        let txt = string x
        label[] [
            input[  Id txt;Type "radio"
                    Name "raceAge";Value txt
                    Style[Visibility "visible"]
                    Checked (model.Age = x)
                    OnClick (fun _ -> dispatch <| Msg.AgeSelection x)
                ]
            span[Style[MarginLeft "20px"]] [ unbox txt]
        ]
    let plus color = pre[Style [Color color]] [ unbox "+" ]

    div[Id "raceDiv";Style[Display DisplayOptions.Block]] [
        div[Class "raceText";Id "raceText";Style[Display DisplayOptions.None]] [
            div[Class "row"] [
                div[Class "col-xs-6 col-xs-offset-3"] [
                    unbox "Press"
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    unbox "for more info about a class."
                ]
            ]
        ]
        div[Id "sliderDivID";Class "sliderDiv";Style[Display DisplayOptions.Block]] [
            yield!
                Age.All
                |> List.map createAgeBlip
        ]

        div[Class "raceCreation";Id "raceCreation"] [
          div[Class "row"] [
            div[Class "col-xs-12 col-xs-offset-1"] [
              div[Class "row"] [
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodHuman.png"]
                  unbox "Human"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign TextAlignOptions.Left]] [
                      div[Class "row"] [
                            div[Class "col-xs-10 col-xs-offset-1"] [
                                unbox "Human"
                            ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                            unbox "Str:"
                            plus "red"
                            br[]
                            unbox "End:"
                            plus "red"
                            br[]
                            unbox "Agi:"
                            plus "green"
                            plus "green"
                            plus "green"
                            plus "green"
                            plus "green"
                            br[]
                            unbox "Dex:"
                            plus "green"
                            plus "green"
                            plus "green"
                            plus "green"
                            plus "green"
                            br[]
                            unbox "Wis:"
                            plus "red"
                            plus "red"
                            br[]
                            unbox "Int:"
                            plus "red"
                            plus "red"
                            br[]
                            unbox "Luc:"
                            plus "green"
                            plus "green"
                            plus "green"
                            plus "green"
                            plus "green"
                            br[]
                        ]
                        div[Class "col-xs-7"] [
                            unbox "Bonuses:"
                            br[]
                            unbox "All Stats: +20%"
                            br[]
                            unbox "Exp Rate: +50%"
                            br[]
                            unbox "Drop Rate: +50%"
                            br[]
                            unbox "Gold Drop: +50%"
                            br[]
                            br[]
                            img[Src "images/races/AdulthoodHuman.png"]
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                            br[]
                            pre[Style [Color "#CC6633"]] [
                                unbox "&quot;Humans possess exceptional drive and a great capacity to endure and expand, and as such are currently the dominant race in the world.&quot;"
                            ]
                        ]
                      ]
                    ]
                  ]
                ]
                div[Class "col-xs-2"] [
                    button[ Type "button";Style[MarginBottom "5px"];Class "btn btn-default border"
                            // onclick "changeRace('Human', 'human');"
                            raceClick Human
                            ] [
                        unbox "Choose"
                    ]
                ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodHalfElf.png"]
                  unbox "Half Elf"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign TextAlignOptions.Left]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            unbox "Half Elf"
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                            unbox "Str:"
                            plus "red"
                            plus "red"
                            br[]
                            unbox "End:"
                            plus "red"
                            plus "red"
                            br[]
                            unbox "Agi:"
                            plus "green"
                            plus "green"
                            plus "green"
                            plus "green"
                            br[]
                            unbox "Dex:"
                            plus "green"
                            plus "green"
                            plus "green"
                            plus "green"
                            br[]
                            unbox "Wis:"
                            plus "green"
                            plus "green"
                            plus "green"
                            plus "green"
                            br[]
                            unbox "Int:"
                            plus "green"
                            plus "green"
                            plus "green"
                            plus "green"
                            br[]
                            unbox "Luc:"
                            plus "red"
                            br[]
                        ]
                        div[Class "col-xs-7"] [
                            unbox "Bonuses:"
                            br[]
                            unbox "All Stats: +10%"
                            br[]
                            unbox "Gold Drop: +30%"
                            br[]
                            unbox "Drop Rate: +30%"
                            br[]
                            unbox "Exp Rate: +30%"
                            br[]
                            unbox "Evasion: +5%"
                            br[]
                            br[]
                            img[Src "images/races/AdulthoodHalfElf.png"]
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[]
                          pre[Style [Color "#CC6633"]] [
                                                unbox "&quot;Elves have long drawn the covetous gazes of other races. Their generous lifespans, magical affinity, and inherent grace each contribute to the admiration or bitter envy of their neighbors.&quot;"
                        ]
                      ]
                    ]
                  ]
                ]
                ]
                div[Class "col-xs-2"] [
                  button[   Type "button";Style[MarginBottom "5px"];Class "btn btn-default border"
                            // onclick "changeRace('Half Elf', 'halfElf');"
                            raceClick HalfElf
                        ] [ unbox "Choose" ]
                ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodDwarf.png"]
                  unbox "Dwarf"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign TextAlignOptions.Left]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [ unbox "Dwarf" ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                          unbox "Str:"
                          plus "red"
                          plus "red"
                          br[]
                          unbox "End:"
                          plus "blue"
                          plus "blue"
                          plus "blue"
                          br[]
                          unbox "Agi:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                          unbox "Dex:"
                          plus "blue"
                          plus "blue"
                          plus "blue"
                          br[]
                          unbox "Wis:"
                          plus "red"
                          plus "red"
                          br[]
                          unbox "Int:"
                          plus "red"
                          br[]
                          unbox "Luc:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                        ]
                        div[Class "col-xs-7"] [
                          unbox "Bonuses:"
                          br[]
                          unbox "Evasion: +5%"
                          br[]
                          unbox "Defense: +20%"
                          br[]
                          unbox "Gold Drop: +100%"
                          br[]
                          unbox "Drop Rate: +50%"
                          br[]
                          br[]
                          img[Src "images/races/AdulthoodDwarf.png"]
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[]
                          pre[Style [Color "#CC6633"]] [
                                                unbox "&quot;Dwarves are a stoic but stern race, ensconced in cities carved from the hearts of mountains and fiercely determined to repel the depredations of savage races like orcs and goblins.&quot;"
                          ]
                        ]
                      ]
                    ]
                  ]
                ]
                div[Class "col-xs-2"] [
                  button[   Type "button";Style[MarginBottom "5px"];Class "btn btn-default border"
                            // onclick "changeRace('Dwarf', 'dwarf');"
                            raceClick Dwarf
                            ] [
                                unbox "Choose"
                  ]
                ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodOrc.png"]
                  unbox "Orc"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign TextAlignOptions.Left]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            unbox "Orc"
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                          unbox "Str:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                          unbox "End:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                          unbox "Agi:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                          unbox "Dex:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                          unbox "Wis:"
                          plus "red"
                          br[]
                          unbox "Int:"
                          plus "red"
                          br[]
                          unbox "Luc:"
                          plus "blue"
                          plus "blue"
                          plus "blue"
                          br[]
                        ]
                        div[Class "col-xs-7"] [
                          unbox "Bonuses:"
                          br[]
                          unbox "Damage: +20%"
                          br[]
                          unbox "Health: +10%"
                          br[]
                          br[]
                          img[Src "images/races/AdulthoodOrc.png"]
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[]
                          pre[Style [Color "#CC6633"]] [
                                                unbox "&quot;Orcs are aggressive, callous, and domineering. Bullies by nature, they respect strength and power as the highest virtues. On an almost instinctive level, orcs believe they are entitled to anything they want unless someone stronger can stop them from seizing it.&quot;"
                          ]
                        ]
                      ]
                    ]
                  ]
                ]
                div[Class "col-xs-2"] [
                  button[   Type "button";Style[MarginBottom "5px"];Class "btn btn-default border"
                            // onclick "changeRace('Orc', 'orc');"
                            raceClick Orc
                        ] [ unbox "Choose" ]
                ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodElf.png"]
                  unbox "Elf"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign TextAlignOptions.Left]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            unbox "Elf"
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                          unbox "Str:"
                          plus "blue"
                          plus "blue"
                          plus "blue"
                          br[]
                          unbox "End:"
                          plus "blue"
                          plus "blue"
                          plus "blue"
                          br[]
                          unbox "Agi:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                          unbox "Dex:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                          unbox "Wis:"
                          plus "red"
                          br[]
                          unbox "Int:"
                          plus "blue"
                          plus "blue"
                          plus "blue"
                          br[]
                          unbox "Luc:"
                          plus "blue"
                          plus "blue"
                          plus "blue"
                          br[]
                        ]
                        div[Class "col-xs-7"] [
                          unbox "Bonuses:"
                          br[]
                          unbox "Never Miss"
                          br[]
                          unbox "Critical Chance: +5%"
                          br[]
                          unbox "Evasion: +5%"
                          br[]
                          unbox "Health: -10%"
                          br[]
                          br[]
                          img[Src "images/races/AdulthoodElf.png"]
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[]
                          pre[Style [Color "#CC6633"]] [
                                                unbox "&quot;The long-lived elves are children of the natural world, similar in many superficial ways to fey creatures, though with key differences.&quot;"
                          ]
                        ]
                      ]
                    ]
                  ]
                ]
                div[Class "col-xs-2"] [
                  button[   Type "button";Style[MarginBottom "5px"];Class "btn btn-default border"
                            // onclick "changeRace('Elf', 'elf');"
                            raceClick Elf
                            ] [ unbox "Choose" ]
                ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodHalfing.png"]
                  unbox "Halfing"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign TextAlignOptions.Left]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            unbox "Halfing"
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                          unbox "Str:"
                          plus "red"
                          br[]
                          unbox "End:"
                          plus "red"
                          br[]
                          unbox "Agi:"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          br[]
                          unbox "Dex:"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          br[]
                          unbox "Wis:"
                          plus "red"
                          plus "red"
                          br[]
                          unbox "Int:"
                          plus "red"
                          br[]
                          unbox "Luc:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                        ]
                        div[Class "col-xs-7"] [
                          unbox "Bonuses:"
                          br[]
                          unbox "Evasion: +10%"
                          br[]
                          unbox "Damage: -10%"
                          br[]
                          unbox "Health: -20%"
                          br[]
                          unbox "Critical Chance: +5%"
                          br[]
                          br[]
                          img[Src "images/races/AdulthoodHalfing.png"]
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[]
                          pre[Style [Color "#CC6633"]] [
                                                unbox "&quot;Optimistic and cheerful by nature, blessed with uncanny luck, and driven by a powerful wanderlust, halflings make up for their short stature with an abundance of bravado and curiosity.&quot;"
                          ]
                        ]
                      ]
                    ]
                  ]
                ]
                div[Class "col-xs-2"] [
                  button[   Type "button";Style[MarginBottom "5px"];Class "btn btn-default border"
                            // onclick "changeRace('Halfing', 'halfing');"
                            raceClick Halfling
                            ] [ unbox "Choose" ]
                ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodSylph.png"]
                  unbox "Sylph"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign TextAlignOptions.Left]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            unbox "Sylph"
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                          unbox "Str:"
                          plus "red"
                          br[]
                          unbox "End:"
                          plus "red"
                          br[]
                          unbox "Agi:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                          unbox "Dex:"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          plus "orange"
                          br[]
                          unbox "Wis:"
                          plus "red"
                          br[]
                          unbox "Int:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                          unbox "Luc:"
                          plus "blue"
                          plus "blue"
                          plus "blue"
                          br[]
                        ]
                        div[Class "col-xs-7"] [
                          unbox "Bonuses:"
                          br[]
                          unbox "Mana Regen: +100%"
                          br[]
                          unbox "Max Mana: +50%"
                          br[]
                          unbox "All Stats: +15%"
                          br[]
                          unbox "Spell Power: +20%"
                          br[]
                          br[]
                          img[Src "images/races/AdulthoodSylph.png"]
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[]
                          pre[Style[Color "#CC6633"]] [
                                                unbox "&quot;Born from the descendants of humans and beings of elemental air such as djinn, sylphs are a shy and reclusive race consumed by intense curiosity.&quot;"
                          ]
                        ]
                      ]
                    ]
                  ]
                ]
                div[Class "col-xs-2"] [
                  button[   Type "button";Style[MarginBottom "5px"];Class "btn btn-default border"
                            // onclick "changeRace('Sylph', 'sylph');"
                            raceClick Sylph
                            ] [ unbox "Choose" ]
                ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodGiant.png"]
                  unbox "Giant"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign TextAlignOptions.Left]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            unbox "Giant"
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                          unbox "Str:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                          unbox "End:"
                          plus "blue"
                          plus "blue"
                          plus "blue"
                          br[]
                          unbox "Agi:"
                          plus "red"
                          plus "red"
                          br[]
                          unbox "Dex:"
                          plus "red"
                          plus "red"
                          br[]
                          unbox "Wis:"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          plus "green"
                          br[]
                          unbox "Int:"
                          plus "red"
                          br[]
                          unbox "Luc:"
                          plus "blue"
                          plus "blue"
                          plus "blue"
                          br[]
                        ]
                        div[Class "col-xs-7"] [
                          unbox "Bonuses:"
                          br[]
                          unbox "Damage: +40%"
                          br[]
                          unbox "Health: +30%"
                          br[]
                          unbox "Max Mana: -50%"
                          br[]
                          unbox "Accuracy: -25%"
                          br[]
                          br[]
                          img[Src "images/races/AdulthoodGiant.png"]
                        ]
                      ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[]
                          pre[Style [Color "#CC6633"]] [
                                                unbox "&quot;Their great size and strength lends them arguable advantages on the battlefield where they tower over their enemies. Dimwitted and slow moving, giants have use for neither speed nor intelligence, using brawn over brain to overcome obstacles.&quot;"
                          ]
                        ]
                      ]
                    ]
                  ]
                ]
                div[Class "col-xs-2"] [
                  button[   Type "button";Style[MarginBottom "5px"];Class "btn btn-default border"
                            // onclick "changeRace('Giant', 'giant');"
                            raceClick Giant
                            ] [ unbox "Choose" ]
                ]
                div[Class "row"] [
                  div[Class "col-xs-2 col-xs-offset-5"] [
                    button[ Type "button";Class "btn btn-default border startBackButtonMargin"
                            // onclick "newGameSlot()"
                            OnClick (fun _ -> Msg.ParentMsg (ParentMsg.CancelRace) |> dispatch)
                          ] [ unbox "Go Back" ]
                ]
              ]
            ]
          ]
        ]
      ]
    ]