namespace Schema

type Monster = {Area:string;Id:string;Name:string;MaxHp:uint;Hp:uint}
    with
        static member Empty = {Area=null;Id=null;Name=null;MaxHp=0u;Hp=0u}

type PlayerMode = Attacks|Spells

type PlayerProperties = {RaceAge:string;RaceImage:string;PlayerMode:PlayerMode}
    with
        static member Empty = {RaceAge=null;RaceImage=null;PlayerMode=Attacks}

