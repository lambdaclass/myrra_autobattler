// <auto-generated>
//   This file was generated by a tool; you should avoid making direct changes.
//   Consider using 'partial classes' to extend these types
//   Input: messages.proto
// </auto-generated>

#region Designer generated code
#pragma warning disable CS0612, CS0618, CS1591, CS3021, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
[global::ProtoBuf.ProtoContract()]
public partial class GameEvent : global::ProtoBuf.IExtensible
{
    private global::ProtoBuf.IExtension __pbn__extensionData;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    [global::ProtoBuf.ProtoMember(1, Name = @"type")]
    public GameEventType Type { get; set; }

    [global::ProtoBuf.ProtoMember(2, Name = @"players")]
    public global::System.Collections.Generic.List<Player> Players { get; } = new global::System.Collections.Generic.List<Player>();

    [global::ProtoBuf.ProtoMember(3, Name = @"latency")]
    public ulong Latency { get; set; }

}

[global::ProtoBuf.ProtoContract()]
public partial class Player : global::ProtoBuf.IExtensible
{
    private global::ProtoBuf.IExtension __pbn__extensionData;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    [global::ProtoBuf.ProtoMember(1, Name = @"id")]
    public ulong Id { get; set; }

    [global::ProtoBuf.ProtoMember(2, Name = @"health", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public long Health { get; set; }

    [global::ProtoBuf.ProtoMember(3, Name = @"position")]
    public Position Position { get; set; }

    [global::ProtoBuf.ProtoMember(4, Name = @"last_melee_attack")]
    public ulong LastMeleeAttack { get; set; }

    [global::ProtoBuf.ProtoMember(5, Name = @"status")]
    public Status Status { get; set; }

    [global::ProtoBuf.ProtoMember(6, Name = @"action")]
    public PlayerAction Action { get; set; }

    [global::ProtoBuf.ProtoMember(7, Name = @"aoe_position")]
    public Position AoePosition { get; set; }

}

[global::ProtoBuf.ProtoContract()]
public partial class Position : global::ProtoBuf.IExtensible
{
    private global::ProtoBuf.IExtension __pbn__extensionData;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    [global::ProtoBuf.ProtoMember(1, Name = @"x")]
    public ulong X { get; set; }

    [global::ProtoBuf.ProtoMember(2, Name = @"y")]
    public ulong Y { get; set; }

}

[global::ProtoBuf.ProtoContract()]
public partial class RelativePosition : global::ProtoBuf.IExtensible
{
    private global::ProtoBuf.IExtension __pbn__extensionData;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    [global::ProtoBuf.ProtoMember(1, Name = @"x")]
    public long X { get; set; }

    [global::ProtoBuf.ProtoMember(2, Name = @"y")]
    public long Y { get; set; }

}

[global::ProtoBuf.ProtoContract()]
public partial class ClientAction : global::ProtoBuf.IExtensible
{
    private global::ProtoBuf.IExtension __pbn__extensionData;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    [global::ProtoBuf.ProtoMember(1, Name = @"action")]
    public Action Action { get; set; }

    [global::ProtoBuf.ProtoMember(2, Name = @"direction")]
    public Direction Direction { get; set; }

    [global::ProtoBuf.ProtoMember(3, Name = @"position")]
    public RelativePosition Position { get; set; }

    [global::ProtoBuf.ProtoMember(4, Name = @"move_delta")]
    public JoystickValues MoveDelta { get; set; }

}

[global::ProtoBuf.ProtoContract()]
public partial class JoystickValues : global::ProtoBuf.IExtensible
{
    private global::ProtoBuf.IExtension __pbn__extensionData;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    [global::ProtoBuf.ProtoMember(1, Name = @"x")]
    public float X { get; set; }

    [global::ProtoBuf.ProtoMember(2, Name = @"y")]
    public float Y { get; set; }

}

[global::ProtoBuf.ProtoContract()]
public partial class LobbyEvent : global::ProtoBuf.IExtensible
{
    private global::ProtoBuf.IExtension __pbn__extensionData;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
        => global::ProtoBuf.Extensible.GetExtensionObject(ref __pbn__extensionData, createIfMissing);

    [global::ProtoBuf.ProtoMember(1, Name = @"type")]
    public LobbyEventType Type { get; set; }

    [global::ProtoBuf.ProtoMember(2, Name = @"lobby_id")]
    [global::System.ComponentModel.DefaultValue("")]
    public string LobbyId { get; set; } = "";

    [global::ProtoBuf.ProtoMember(3, Name = @"player_id")]
    public ulong PlayerId { get; set; }

    [global::ProtoBuf.ProtoMember(4, Name = @"added_player_id")]
    public ulong AddedPlayerId { get; set; }

    [global::ProtoBuf.ProtoMember(5, Name = @"game_id")]
    [global::System.ComponentModel.DefaultValue("")]
    public string GameId { get; set; } = "";

    [global::ProtoBuf.ProtoMember(6, Name = @"player_count")]
    public ulong PlayerCount { get; set; }

}

[global::ProtoBuf.ProtoContract()]
public enum GameEventType
{
    [global::ProtoBuf.ProtoEnum(Name = @"STATE_UPDATE")]
    StateUpdate = 0,
    [global::ProtoBuf.ProtoEnum(Name = @"PING_UPDATE")]
    PingUpdate = 1,
}

[global::ProtoBuf.ProtoContract()]
public enum Status
{
    [global::ProtoBuf.ProtoEnum(Name = @"ALIVE")]
    Alive = 0,
    [global::ProtoBuf.ProtoEnum(Name = @"DEAD")]
    Dead = 1,
}

[global::ProtoBuf.ProtoContract()]
public enum Action
{
    [global::ProtoBuf.ProtoEnum(Name = @"ACTION_UNSPECIFIED")]
    ActionUnspecified = 0,
    [global::ProtoBuf.ProtoEnum(Name = @"MOVE")]
    Move = 1,
    [global::ProtoBuf.ProtoEnum(Name = @"ATTACK")]
    Attack = 2,
    [global::ProtoBuf.ProtoEnum(Name = @"ATTACK_AOE")]
    AttackAoe = 5,
    [global::ProtoBuf.ProtoEnum(Name = @"MOVE_WITH_JOYSTICK")]
    MoveWithJoystick = 6,
}

[global::ProtoBuf.ProtoContract()]
public enum Direction
{
    [global::ProtoBuf.ProtoEnum(Name = @"DIRECTION_UNSPECIFIED")]
    DirectionUnspecified = 0,
    [global::ProtoBuf.ProtoEnum(Name = @"UP")]
    Up = 1,
    [global::ProtoBuf.ProtoEnum(Name = @"DOWN")]
    Down = 2,
    [global::ProtoBuf.ProtoEnum(Name = @"LEFT")]
    Left = 3,
    [global::ProtoBuf.ProtoEnum(Name = @"RIGHT")]
    Right = 4,
}

[global::ProtoBuf.ProtoContract()]
public enum PlayerAction
{
    [global::ProtoBuf.ProtoEnum(Name = @"NOTHING")]
    Nothing = 0,
    [global::ProtoBuf.ProtoEnum(Name = @"ATTACKING")]
    Attacking = 1,
    [global::ProtoBuf.ProtoEnum(Name = @"ATTACKING_AOE")]
    AttackingAoe = 2,
}

[global::ProtoBuf.ProtoContract()]
public enum LobbyEventType
{
    [global::ProtoBuf.ProtoEnum(Name = @"TYPE_UNSPECIFIED")]
    TypeUnspecified = 0,
    [global::ProtoBuf.ProtoEnum(Name = @"CONNECTED")]
    Connected = 1,
    [global::ProtoBuf.ProtoEnum(Name = @"PLAYER_ADDED")]
    PlayerAdded = 2,
    [global::ProtoBuf.ProtoEnum(Name = @"GAME_STARTED")]
    GameStarted = 3,
    [global::ProtoBuf.ProtoEnum(Name = @"PLAYER_COUNT")]
    PlayerCount = 4,
    [global::ProtoBuf.ProtoEnum(Name = @"START_GAME")]
    StartGame = 5,
}

#pragma warning restore CS0612, CS0618, CS1591, CS3021, IDE0079, IDE1006, RCS1036, RCS1057, RCS1085, RCS1192
#endregion
