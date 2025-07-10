using System;
using System.Collections.Generic;

public class PageToRead
{
    public int PageNumber { get; set; }
    public PageToRead NextPage { get; set; }

    private PageToRead head;
    private List<PageToRead> pageSequence = new List<PageToRead>();
    private Dictionary<int, PageToRead> uniquePages = new Dictionary<int, PageToRead>();
    private bool hasLoop = false;
    //
    //Parses a comma-separated list of integers.
    //Detects loops by identifying repeated page numbers.
    //If a loop exists, ensures there's no data after the loop starts again.
    //Returns a tuple indicating success and an error message if applicable.
    public (bool success, string message) Create(string sequenceOfPages)
    {
        head = null;
        pageSequence.Clear();
        uniquePages.Clear();
        hasLoop = false;

        if (string.IsNullOrWhiteSpace(sequenceOfPages))
            return (false, "Input string is empty");

        var tokens = sequenceOfPages.Split(',');
        var seen = new Dictionary<int, int>(); // Value = index of first appearance

        int index = 0;
        PageToRead prev = null;
        foreach (var token in tokens)
        {
            if (!int.TryParse(token.Trim(), out int pageNumber))
                return (false, $"Invalid page number: '{token.Trim()}'");

            if (seen.TryGetValue(pageNumber, out int loopStartIndex))
            {
                // Loop detected
                hasLoop = true;
                if (index > loopStartIndex)
                {
                    // Check if loop is at the end
                    if (index != tokens.Length - 1)
                        return (false, $"Invalid sequence: data after loop at page {pageNumber}");
                }
                if(hasLoop)
                {
                    return (true, $"but we see the loop {pageNumber}");
                }
            }
            else
            {
                seen[pageNumber] = index;
            }

            PageToRead current = new PageToRead { PageNumber = pageNumber };
            if (prev != null)
            {
                prev.NextPage = current;
            }
            else
            {
                head = current;
            }

            if (!uniquePages.ContainsKey(pageNumber))
                uniquePages[pageNumber] = current;

            pageSequence.Add(current);
            prev = current;
            index++;
        }

        // Set up loop connection if needed
        if (hasLoop)
        {
            int loopStart = seen[pageSequence[^1].PageNumber];
            pageSequence[^1].NextPage = pageSequence[loopStart];
        }

        return (true, "");
    }

    //  Returns count of unique pages using a dictionary.
    public int CountOfPages()
    {
        return uniquePages.Count;
    }
    // Uses the internal pageSequence list to fetch the page at the given index.
    public PageToRead PageAt(int pageIndex)
    {
        if (pageIndex < 0 || pageIndex >= pageSequence.Count)
            return null;

        return pageSequence[pageIndex];
    }
    //Returns:    The last page in the list if no loop; The last page before the loop if a loop is detected.
    public PageToRead LastPage()
    {
        if (pageSequence.Count == 0)
            return null;

        if (hasLoop)
        {
            return pageSequence[^2]; // Second to last before loop connects
        }

        return pageSequence[^1];
    }
}