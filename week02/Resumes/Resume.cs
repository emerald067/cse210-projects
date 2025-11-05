using System;

public class Resume
{
    // Create the member variable for the name.
    public string _name;

    // Create the member variable for the list of Jobs and initialize it to a new string.
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Iterate through each job in the list of jobs
        foreach (Job job in _jobs)
        {
            // Display method on each job
            job.Display();
        }
    }
}