module Save

open Elmish
open Elmish.React
open Fable.React
open Fable.React.Props

open Schema
open FableHelpers

module Dynamic =
    let imageRaceSrc image = sprintf "images/races/%s.png" image

    let checkHeroRace (characterRaces: CharacterRace seq) playerHeroRace =
        characterRaces
        |> Seq.tryFind(fun heroRace -> heroRace.Type = playerHeroRace)
        |> function
            |None -> div[][]
            |Some heroRace ->
                div [][
                    a[Href"#";Class "tooltipA"][
                        img[Src <| imageRaceSrc heroRace.Image]
                    ]
                ]
    ()


    let characterCreationHtml races (playerProperties:_ option) =
        div[Id "raceDiv";Style[Display DisplayOptions.Block]][
            div[Id "sliderDivID";Class"sliderDiv";Style[Display DisplayOptions.Block]][

            ]
        ]


let newGame confirm slot =
    if confirm "Are you sure?" then
        ()
    ()
