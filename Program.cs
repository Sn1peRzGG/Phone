using Spectre.Console;
using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, string> contacts = new Dictionary<string, string>();

    static void Main()
    {
        bool running = true;
        while (running)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Choose an action:")
                .AddChoices("Add Contact", "Delete Contact", "View Contacts", "Exit"));

            switch (choice)
            {
                case "Add Contact": AddContact(); break;
                case "Delete Contact": DeleteContact(); break;
                case "View Contacts": ViewContacts(); break;
                case "Exit": running = false; break;
            }
        }
    }

    static void AddContact()
    {
        string name = AnsiConsole.Ask<string>("Enter contact name:");
        string phone = AnsiConsole.Ask<string>("Enter phone number:");
        contacts[name] = phone;
        AnsiConsole.MarkupLine("[green]Contact added.[/]");
    }

    static void DeleteContact()
    {
        string name = AnsiConsole.Ask<string>("Enter contact name to delete:");
        if (contacts.ContainsKey(name))
        {
            contacts.Remove(name);
            AnsiConsole.MarkupLine("[green]Contact deleted.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Contact not found.[/]");
        }
    }

    static void ViewContacts()
    {
        if (contacts.Count > 0)
        {
            foreach (var contact in contacts)
            {
                AnsiConsole.MarkupLine($"[yellow]{contact.Key}: {contact.Value}[/]");
            }
        }
        else
        {
            AnsiConsole.MarkupLine("[red]No contacts available.[/]");
        }
    }
}
