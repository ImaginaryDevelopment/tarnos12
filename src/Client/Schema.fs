namespace Schema

type Monster = {Area:string;Id:string;Name:string;MaxHp:uint;Hp:uint}
    with
        static member Empty = {Area=null;Id=null;Name=null;MaxHp=0u;Hp=0u}

type PlayerMode = Attacks|Spells

type Age = | Adulthood | MiddleAge | Old | Venerable
    with
        static member All = [
            Adulthood
            MiddleAge
            Old
            Venerable
        ]

type CharacterRaceType=
    |Human
    |HalfElf
    |Dwarf
    |Orc
    |Elf
    |Halfling
    |Sylph
    |Giant

type Stat = uint
type CharacterRace = {  Type:CharacterRaceType;Image:string;Age:Age;
                        Strength:Stat;Endurance:Stat;Agility:Stat
                        Dexterity:Stat;Wisdom:Stat;Intelligence:Stat
                        Luck:Stat
                        }

type PlayerProperties = {CharacterRace:CharacterRace;PlayerMode:PlayerMode}
    // with
    //     static member Empty = {CharacterRace=None;PlayerMode=Attacks}
