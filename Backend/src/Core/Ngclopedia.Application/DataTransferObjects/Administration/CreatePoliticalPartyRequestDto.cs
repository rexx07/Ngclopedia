﻿namespace Ngclopedia.Application.DataTransferObjects.Administration;

public class CreatePoliticalPartyRequestDto
{
    public string Name { get; init; }
    public string PartyChairman { get; init; }
    public string PartySecretary { get; init; }
    public string GoverningBody { get; init; }
    public DateTime Founded { get; init; }
    public int? EstMembersCount { get; init; }
}