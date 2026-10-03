using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it. Remember to both express the solution
    /// in terms of recursive call on a smaller problem and
    /// to identify a base case (terminating case). If the value of
    /// n <= 0, just return 0. A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
            return 0;

        // Recursive case
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: the word has reached the requested size
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try each available letter
        for (int i = 0; i < letters.Length; i++)
        {
            char letter = letters[i];

            // Remove the selected letter so it cannot be used again
            string remainingLetters = letters.Remove(i, 1);

            // Recursively build the rest of the word
            PermutationsChoose(
                results,
                remainingLetters,
                size,
                word + letter
            );
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb the stairs using
    /// 1, 2, or 3 steps at a time.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base cases
        if (s == 0)
            return 0;

        if (s == 1)
            return 1;

        if (s == 2)
            return 2;

        if (s == 3)
            return 4;

        // Create the dictionary the first time the function runs
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Check whether we already calculated this value
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive calculation
        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        // Remember the result so we don't calculate it again
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Insert all possible binary strings represented by
    /// the wildcard pattern into the results list.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Find the next wildcard
        int wildcardIndex = pattern.IndexOf('*');

        // Base case: there are no more wildcards
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace the wildcard with 0 and recurse
        string zeroPattern =
            pattern[..wildcardIndex] +
            "0" +
            pattern[(wildcardIndex + 1)..];

        WildcardBinary(zeroPattern, results);

        // Replace the wildcard with 1 and recurse
        string onePattern =
            pattern[..wildcardIndex] +
            "1" +
            pattern[(wildcardIndex + 1)..];

        WildcardBinary(onePattern, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function,
        // initialize the current path.
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Check if this is a valid position.
        if (!maze.IsValidMove(currPath, x, y))
            return;

        // Add the current position to the path.
        currPath.Add((x, y));

        // Check if we have reached the end.
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Try moving right.
        SolveMaze(results, maze, x + 1, y, currPath);

        // Try moving left.
        SolveMaze(results, maze, x - 1, y, currPath);

        // Try moving down.
        SolveMaze(results, maze, x, y + 1, currPath);

        // Try moving up.
        SolveMaze(results, maze, x, y - 1, currPath);

        // Backtrack so another path can be explored.
        currPath.RemoveAt(currPath.Count - 1);
    }
}