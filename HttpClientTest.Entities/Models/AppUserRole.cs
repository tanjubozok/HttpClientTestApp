﻿namespace HttpClientTest.Entities.Models;

public class AppUserRole : IBaseEntity
{
    public int Id { get; set; }

    public int AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public int AppRoleId { get; set; }
    public AppRole? AppRole { get; set; }
}
