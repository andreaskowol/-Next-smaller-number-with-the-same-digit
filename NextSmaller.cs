     /*Strategy
     * Starting from the end of the number
     * Find first digit "gd" that is greater than previous digit
     * Next find the smallest "sn" number in numbers from index "gd + 1" to the end of the number
     * Swap "gd" and "sn"
     * Sort desc from the index "gd + 1" to the end of the list
     */
     
    public static long NextSmaller(long n)
    {
        long[] number = n.ToString().Select(o => (long)Convert.ToInt32(o) - 48).ToArray();
        long nextSmallest = -1;
        long nextSmallestCount = -1;
        int index = number.Length-1;

        var seqence = number.OrderBy(x => x).ToArray();

        if (number.Length == 1 || Enumerable.SequenceEqual(number, seqence))
            return -1;

        for (int i = number.Length-1; i > 0; i--)
        {
            if (number[i - 1] > number[i]) { index = i - 1; break; }
            else { index--; }
        }

        for (int i = index; i < number.Length; i++)
        {
            if (number[i] < number[index] && number[i] > nextSmallest) { nextSmallest = number[i]; nextSmallestCount = i; }
        }

        (number[index], number[nextSmallestCount]) = (number[nextSmallestCount], number[index]);

        var numbers2 = number.ToList().GetRange(index+1, number.Length - 1 - index).ToArray();
        numbers2 = numbers2.OrderByDescending(x => x).ToArray();
         
        for (int i = 0; i < numbers2.Length; i++)
        {
            number[i+index+1] = numbers2[i];
        }

        var result = string.Join("", number);
        var resultValidated =  result[0] != '0' ? long.Parse(result) : -1;

        return resultValidated < n ? resultValidated : -1;
    }
