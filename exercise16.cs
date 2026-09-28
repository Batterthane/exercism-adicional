// Exercism practica 16 Isandel Abreu

//Attack of the Trolls

using System;

enum AccountType
{
    Guest,
    User,
    Moderator
}

[Flags]
enum Permission
{
    None = 0b_0000_0000,
    Read = 0b_0000_0001,
    Write = 0b_0000_0010,
    Delete = 0b_0000_0100,
    All = Read | Write | Delete
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        switch (accountType)
        {
            case AccountType.Guest:
                return Permission.Read;
            case AccountType.User:
                return Permission.Read | Permission.Write;
            case AccountType.Moderator:
                return Permission.Read | Permission.Write | Permission.Delete;
            default:
                return Permission.None;
        }
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current & ~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
        return current.HasFlag(check);
    }
}

class Program
{
    static void Main()
    {
        Permission guestPermissions =
            Permissions.Default(AccountType.Guest);

        Permission userPermissions =
            Permissions.Default(AccountType.User);

        Permission moderatorPermissions =
            Permissions.Default(AccountType.Moderator);

        Console.WriteLine("Guest: " + guestPermissions);
        Console.WriteLine("User: " + userPermissions);
        Console.WriteLine("Moderator: " + moderatorPermissions);

        Permission granted =
            Permissions.Grant(guestPermissions, Permission.Write);

        Console.WriteLine("Guest after Write: " + granted);

        Permission revoked =
            Permissions.Revoke(granted, Permission.Read);

        Console.WriteLine("After removing Read: " + revoked);

        Console.WriteLine(
            "Has Write: " +
            Permissions.Check(revoked, Permission.Write));

        Console.WriteLine(
            "Has Delete: " +
            Permissions.Check(revoked, Permission.Delete));
    }
}