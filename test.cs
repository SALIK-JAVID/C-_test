using System;
using System.Collections.Generic;

class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

class ContactsManager
{
    private List<Contact> contacts = new List<Contact>();

    public void AddContact(string name, string phone, string email)
    {
        contacts.Add(new Contact { Name = name, PhoneNumber = phone, Email = email });
        Console.WriteLine("Contact added successfully!");
    }

    public void ViewContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts available.");
            return;
        }
        
        Console.WriteLine("\nContacts List:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
        }
    }

    public void UpdateContact(string name)
    {
        var contact = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (contact != null)
        {
            Console.Write("Enter new phone number: ");
            contact.PhoneNumber = Console.ReadLine();
            Console.Write("Enter new email: ");
            contact.Email = Console.ReadLine();
            Console.WriteLine("Contact updated successfully!");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }

    public void DeleteContact(string name)
    {
        var contact = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (contact != null)
        {
            contacts.Remove(contact);
            Console.WriteLine("Contact deleted successfully!");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        ContactsManager manager = new ContactsManager();
        while (true)
        {
            Console.WriteLine("\nContacts Management System");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. View Contacts");
            Console.WriteLine("3. Update Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter phone number: ");
                    string phone = Console.ReadLine();
                    Console.Write("Enter email: ");
                    string email = Console.ReadLine();
                    manager.AddContact(name, phone, email);
                    break;
                case "2":
                    manager.ViewContacts();
                    break;
                case "3":
                    Console.Write("Enter name of contact to update: ");
                    string updateName = Console.ReadLine();
                    manager.UpdateContact(updateName);
                    break;
                case "4":
                    Console.Write("Enter name of contact to delete: ");
                    string deleteName = Console.ReadLine();
                    manager.DeleteContact(deleteName);
                    break;
                case "5":
                    Console.WriteLine("Exiting... Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
