public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
 
        double[] result = new double[length]; //Create a new array to store the multiples (the size is fixed by the length parameter)

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);   //Calculate each multiple and store it in the array
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        int lastElementsStartIndex = data.Count - amount;                     //This first line gets the index where the new temporary list with the itens that will be moved to the front will start
        List<int> tempList = data.GetRange(lastElementsStartIndex, amount);  //This line creates a temporary list with the items that will be moved to the front of the original list
        data.RemoveRange(lastElementsStartIndex, amount);                    //This line removes the items that were copied to the temporary list from the original list
        data.InsertRange(0, tempList);                                      //This line inserts the items from the temporary list to the front of the original list



    }
}
