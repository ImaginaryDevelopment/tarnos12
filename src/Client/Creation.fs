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
    | RaceSelection of CharacterRace

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
    div[Id "raceDiv";Style[Display Block]] [
        div[Class "raceText";Id "raceText";Style[Display None]] [
            div[Class "row"] [
                div[Class "col-xs-6 col-xs-offset-3"] [
                    Unbox "Press"
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    Unbox "for more info about a class."
                ]
            ]
        ]
        div[Id "sliderDivID";Class "sliderDiv";Style[Display Block]] [

            label[] [
                input[Id "Adulthood";Type "radio";Name "raceAge";Value "Adulthood";Style[Visibility Visible];onclick "getAgeButton()";Checked false][]
                span[Style[MarginLeft "20px"]] [
                        Unbox "Adulthood"
                ]
            ]

            label[] [
                input[  Id "Middle Age";Type "radio";Name "raceAge";Value "Middle Age"
                        Style[Visibility Visible];onclick "getAgeButton()"][]
                span[Style[MarginLeft "20px"]] [
                    Unbox "Middle Age"
                ]
            ]

            label[] [
                input[Id "Old";Type "radio";Name "raceAge";Value "Old";Style[Visibility Visible];onclick "getAgeButton()"][]
                span[Style[MarginLeft "20px"]] [
                    Unbox "Old"
                ]
            ]

            label[] [
                input[Id "Venerable";Type "radio";Name "raceAge";Value "Venerable";Style[Visibility Visible];onclick "getAgeButton()"][]
                span[Style[MarginLeft "20px"]] [
                        Unbox "Venerable"
                ]
            ]

        ]

        div[Class "raceCreation";Id "raceCreation"] [
          div[Class "row"] [
            div[Class "col-xs-12 col-xs-offset-1"] [
              div[Class "row"] [
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodHuman.png"][]
                            Unbox "Human"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign "left"]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            Unbox "Human"
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                                            Unbox "Str:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "End:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Agi:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Dex:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Wis:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Int:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Luc:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                      ]
                        div[Class "col-xs-7"] [
                                            Unbox "Bonuses:"
                          br[][]
                                            Unbox "All Stats: +20%"
                          br[][]
                                            Unbox "Exp Rate: +50%"
                          br[][]
                                            Unbox "Drop Rate: +50%"
                          br[][]
                                            Unbox "Gold Drop: +50%"
                          br[][]
                          br[][]
                          img[Src "images/races/AdulthoodHuman.png"][]
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[][]
                          font[color "#CC6633"] [
                                                Unbox "&quot;Humans possess exceptional drive and a great capacity to endure and expand, and as such are currently the dominant race in the world.&quot;"
                        ]
                      ]
                    ]
                  ]
                ]
              ]
                div[Class "col-xs-2"] [
                  button[type "button";Style[MarginBottom "5px"];Class "btn btn-default border";onclick "changeRace('Human', 'human');"] [
                                Unbox "Choose"
                ]
              ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodHalfElf.png"][]
                            Unbox "Half Elf"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign "left"]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            Unbox "Half Elf"
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                                            Unbox "Str:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "End:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Agi:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Dex:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Wis:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Int:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Luc:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                      ]
                        div[Class "col-xs-7"] [
                                            Unbox "Bonuses:"
                          br[][]
                                            Unbox "All Stats: +10%"
                          br[][]
                                            Unbox "Gold Drop: +30%"
                          br[][]
                                            Unbox "Drop Rate: +30%"
                          br[][]
                                            Unbox "Exp Rate: +30%"
                          br[][]
                                            Unbox "Evasion: +5%"
                          br[][]
                          br[][]
                          img[Src "images/races/AdulthoodHalfElf.png"][]
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[][]
                          font[color "#CC6633"] [
                                                Unbox "&quot;Elves have long drawn the covetous gazes of other races. Their generous lifespans, magical affinity, and inherent grace each contribute to the admiration or bitter envy of their neighbors.&quot;"
                        ]
                      ]
                    ]
                  ]
                ]
              ]
                div[Class "col-xs-2"] [
                  button[type "button";Style[MarginBottom "5px"];Class "btn btn-default border";onclick "changeRace('Half Elf', 'halfElf');"] [
                                Unbox "Choose"
                ]
              ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodDwarf.png"][]
                            Unbox "Dwarf"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign "left"]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            Unbox "Dwarf"
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                                            Unbox "Str:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "End:"
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Agi:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Dex:"
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Wis:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Int:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Luc:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                      ]
                        div[Class "col-xs-7"] [
                                            Unbox "Bonuses:"
                          br[][]
                                            Unbox "Evasion: +5%"
                          br[][]
                                            Unbox "Defense: +20%"
                          br[][]
                                            Unbox "Gold Drop: +100%"
                          br[][]
                                            Unbox "Drop Rate: +50%"
                          br[][]
                          br[][]
                          img[Src "images/races/AdulthoodDwarf.png"][]
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[][]
                          font[color "#CC6633"] [
                                                Unbox "&quot;Dwarves are a stoic but stern race, ensconced in cities carved from the hearts of mountains and fiercely determined to repel the depredations of savage races like orcs and goblins.&quot;"
                        ]
                      ]
                    ]
                  ]
                ]
              ]
                div[Class "col-xs-2"] [
                  button[type "button";Style[MarginBottom "5px"];Class "btn btn-default border";onclick "changeRace('Dwarf', 'dwarf');"] [
                                Unbox "Choose"
                ]
              ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodOrc.png"][]
                            Unbox "Orc"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign "left"]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            Unbox "Orc"
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                                            Unbox "Str:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "End:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Agi:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Dex:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Wis:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Int:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Luc:"
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          br[][]
                      ]
                        div[Class "col-xs-7"] [
                                            Unbox "Bonuses:"
                          br[][]
                                            Unbox "Damage: +20%"
                          br[][]
                                            Unbox "Health: +10%"
                          br[][]
                          br[][]
                          img[Src "images/races/AdulthoodOrc.png"][]
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[][]
                          font[color "#CC6633"] [
                                                Unbox "&quot;Orcs are aggressive, callous, and domineering. Bullies by nature, they respect strength and power as the highest virtues. On an almost instinctive level, orcs believe they are entitled to anything they want unless someone stronger can stop them from seizing it.&quot;"
                        ]
                      ]
                    ]
                  ]
                ]
              ]
                div[Class "col-xs-2"] [
                  button[type "button";Style[MarginBottom "5px"];Class "btn btn-default border";onclick "changeRace('Orc', 'orc');"] [
                                Unbox "Choose"
                ]
              ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodElf.png"][]
                            Unbox "Elf"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign "left"]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            Unbox "Elf"
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                                            Unbox "Str:"
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "End:"
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Agi:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Dex:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Wis:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Int:"
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Luc:"
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          br[][]
                      ]
                        div[Class "col-xs-7"] [
                                            Unbox "Bonuses:"
                          br[][]
                                            Unbox "Never Miss"
                          br[][]
                                            Unbox "Critical Chance: +5%"
                          br[][]
                                            Unbox "Evasion: +5%"
                          br[][]
                                            Unbox "Health: -10%"
                          br[][]
                          br[][]
                          img[Src "images/races/AdulthoodElf.png"][]
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[][]
                          font[color "#CC6633"] [
                                                Unbox "&quot;The long-lived elves are children of the natural world, similar in many superficial ways to fey creatures, though with key differences.&quot;"
                        ]
                      ]
                    ]
                  ]
                ]
              ]
                div[Class "col-xs-2"] [
                  button[type "button";Style[MarginBottom "5px"];Class "btn btn-default border";onclick "changeRace('Elf', 'elf');"] [
                                Unbox "Choose"
                ]
              ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodHalfing.png"][]
                            Unbox "Halfing"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign "left"]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            Unbox "Halfing"
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                                            Unbox "Str:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "End:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Agi:"
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Dex:"
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Wis:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Int:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Luc:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                      ]
                        div[Class "col-xs-7"] [
                                            Unbox "Bonuses:"
                          br[][]
                                            Unbox "Evasion: +10%"
                          br[][]
                                            Unbox "Damage: -10%"
                          br[][]
                                            Unbox "Health: -20%"
                          br[][]
                                            Unbox "Critical Chance: +5%"
                          br[][]
                          br[][]
                          img[Src "images/races/AdulthoodHalfing.png"][]
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[][]
                          font[color "#CC6633"] [
                                                Unbox "&quot;Optimistic and cheerful by nature, blessed with uncanny luck, and driven by a powerful wanderlust, halflings make up for their short stature with an abundance of bravado and curiosity.&quot;"
                        ]
                      ]
                    ]
                  ]
                ]
              ]
                div[Class "col-xs-2"] [
                  button[type "button";Style[MarginBottom "5px"];Class "btn btn-default border";onclick "changeRace('Halfing', 'halfing');"] [
                                Unbox "Choose"
                ]
              ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodSylph.png"][]
                            Unbox "Sylph"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign "left"]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            Unbox "Sylph"
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                                            Unbox "Str:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "End:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Agi:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Dex:"
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          font[color "orange"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Wis:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Int:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Luc:"
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          br[][]
                      ]
                        div[Class "col-xs-7"] [
                                            Unbox "Bonuses:"
                          br[][]
                                            Unbox "Mana Regen: +100%"
                          br[][]
                                            Unbox "Max Mana: +50%"
                          br[][]
                                            Unbox "All Stats: +15%"
                          br[][]
                                            Unbox "Spell Power: +20%"
                          br[][]
                          br[][]
                          img[Src "images/races/AdulthoodSylph.png"][]
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[][]
                          font[color "#CC6633"] [
                                                Unbox "&quot;Born from the descendants of humans and beings of elemental air such as djinn, sylphs are a shy and reclusive race consumed by intense curiosity.&quot;"
                        ]
                      ]
                    ]
                  ]
                ]
              ]
                div[Class "col-xs-2"] [
                  button[type "button";Style[MarginBottom "5px"];Class "btn btn-default border";onclick "changeRace('Sylph', 'sylph');"] [
                                Unbox "Choose"
                ]
              ]
                div[Class "col-xs-6 col-xs-offset-2"] [
                  img[Src "images/races/AdulthoodGiant.png"][]
                            Unbox "Giant"
                  a[Class "tooltips"] [
                    p[Class "glyphicon glyphicon-info-sign";Style[Color "black"]][]
                    span[Style[Width "350px";Left "110px";Bottom "-30px";TextAlign "left"]] [
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                                            Unbox "Giant"
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-5";Style[PaddingLeft "46px"]] [
                                            Unbox "Str:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "End:"
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Agi:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Dex:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Wis:"
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          font[color "green"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Int:"
                          font[color "red"] [
                                                Unbox "+"
                        ]
                          br[][]
                                            Unbox "Luc:"
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          font[color "blue"] [
                                                Unbox "+"
                        ]
                          br[][]
                      ]
                        div[Class "col-xs-7"] [
                                            Unbox "Bonuses:"
                          br[][]
                                            Unbox "Damage: +40%"
                          br[][]
                                            Unbox "Health: +30%"
                          br[][]
                                            Unbox "Max Mana: -50%"
                          br[][]
                                            Unbox "Accuracy: -25%"
                          br[][]
                          br[][]
                          img[Src "images/races/AdulthoodGiant.png"][]
                      ]
                    ]
                      div[Class "row"] [
                        div[Class "col-xs-10 col-xs-offset-1"] [
                          br[][]
                          font[color "#CC6633"] [
                                                Unbox "&quot;Their great size and strength lends them arguable advantages on the battlefield where they tower over their enemies. Dimwitted and slow moving, giants have use for neither speed nor intelligence, using brawn over brain to overcome obstacles.&quot;"
                        ]
                      ]
                    ]
                  ]
                ]
              ]
                div[Class "col-xs-2"] [
                  button[type "button";Style[MarginBottom "5px"];Class "btn btn-default border";onclick "changeRace('Giant', 'giant');"] [
                                Unbox "Choose"
                ]
              ]
                div[Class "row"] [
                  div[Class "col-xs-2 col-xs-offset-5"] [
                    button[type "button";Class "btn btn-default border startBackButtonMargin";onclick "newGameSlot()"] [
                                    Unbox "Go Back"
                  ]
                ]
              ]
            ]
          ]
        ]
      ]

    ]