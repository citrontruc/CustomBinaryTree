/*
A set of methods to find common values in two lists of values.
*/

public static class ListComparer
{
    /// <summary>
    /// Removing duplicates has a complexity of O(n) (create a dictionary and get the keys).
    /// We iterate on the two lists (n and then m operations) with n and m being the length of our two lists.
    /// Total complexity is ~O(2*(n + m))
    /// </summary>
    /// <typeparam name="T">The type of the list elements</typeparam>
    /// <param name="firstList"></param>
    /// <param name="secondList"></param>
    /// <returns>A list of all the elements in both lists 1 and 2</returns>
    public static List<T> CompareWithDict<T>(List<T> firstList, List<T> secondList)
        where T : IComparable<T>
    {
        HashSet<T> comparisonHashSet = new();
        List<T> result = new();

        for (int i = 0; i < firstList.Count(); i++)
        {
            comparisonHashSet.Add(firstList[i]);
        }

        List<T> distinctSecondListValues = secondList.Distinct().ToList();
        for (int i = 0; i < distinctSecondListValues.Count(); i++)
        {
            if (comparisonHashSet.TryGetValue(distinctSecondListValues[i], out _))
            {
                result.Add(secondList[i]);
            }
        }

        return result;
    }

    /// <summary>
    /// Removing duplicates has a complexity of O(n) (create a dictionary and get the keys).
    /// Sorting has a complexity of O(ln(n)). We then have the comparison by increment which has a complexity of O(n+m).
    /// total complexity is ~O(n * ln(n) + m * ln(m))
    /// </summary>
    /// <typeparam name="T">The type of the list elements</typeparam>
    /// <param name="firstList"></param>
    /// <param name="secondList"></param>
    /// <returns>A list of all the elements in both lists 1 and 2</returns>
    public static List<T> CompareWithSort<T>(List<T> firstList, List<T> secondList)
        where T : IComparable<T>
    {
        List<T> result = new();
        List<T> firstListNoDuplicates = firstList.Distinct().ToList();
        List<T> secondListNoDuplicates = secondList.Distinct().ToList();
        firstListNoDuplicates.Sort();
        secondListNoDuplicates.Sort();
        int counterFirstList = 0;
        int counterSecondList = 0;
        while (
            counterFirstList < firstListNoDuplicates.Count()
            && counterSecondList < secondListNoDuplicates.Count()
        )
        {
            switch (
                firstListNoDuplicates[counterFirstList]
                    .CompareTo(secondListNoDuplicates[counterSecondList])
            )
            {
                case < 0:
                    counterFirstList++;
                    break;
                case 0:
                    result.Add(firstListNoDuplicates[counterFirstList]);
                    counterFirstList++;
                    break;
                case > 0:
                    counterSecondList++;
                    break;
            }
        }

        return result;
    }

    /// <summary>
    /// Removing duplicates has a complexity of O(n) (create a dictionary and get the keys).
    /// Creating the tree has an average complexity of O(n * ln(n)) and a worst case complexity of O(n**2).
    /// We then have complexity of O(m * ln(n)) (m comparison operations of complexity ln(n)).
    /// Total complexity is ~ O((n + m) * ln(n))
    /// </summary>
    /// <typeparam name="T">The type of the list elements</typeparam>
    /// <param name="firstList"></param>
    /// <param name="secondList"></param>
    /// <returns>A list of all the elements in both lists 1 and 2</returns>
    public static List<T> CompareWithBST<T>(List<T> firstList, List<T> secondList)
        where T : IComparable<T>
    {
        if (firstList.Count() == 0)
        {
            return new();
        }

        List<T> result = new();
        List<T> firstListNoDuplicates = firstList.Distinct().ToList();
        List<T> secondListNoDuplicates = secondList.Distinct().ToList();
        BinarySearchTree<T> binarySearchTree = new(firstListNoDuplicates[0]);
        for (int i = 1; i < firstListNoDuplicates.Count(); i++)
        {
            binarySearchTree.AddNode(firstListNoDuplicates[i]);
        }

        for (int i = 0; i < secondListNoDuplicates.Count(); i++)
        {
            if (binarySearchTree.Contains(secondListNoDuplicates[i]))
            {
                result.Add(secondListNoDuplicates[i]);
            }
        }

        return result;
    }

    /// <summary>
    /// /// Removing duplicates has a complexity of O(n) (create a dictionary and get the keys).
    /// The Linq Contains method has a complexity of O(n) for lists (we check every elements).
    /// We call the method for every elements ==> Total complexity is O(n * m);
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="firstList"></param>
    /// <param name="secondList"></param>
    /// <returns></returns>
    public static List<T> CompareWithLinq<T>(List<T> firstList, List<T> secondList)
        where T : IComparable<T>
    {
        List<T> result = new();
        List<T> firstListNoDuplicates = firstList.Distinct().ToList();
        for (int i = 0; i < firstListNoDuplicates.Count(); i++)
        {
            if (secondList.Contains(firstListNoDuplicates[i]))
            {
                result.Add(firstListNoDuplicates[i]);
            }
        }

        return result;
    }
}
