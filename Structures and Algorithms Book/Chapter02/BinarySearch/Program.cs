int BinarySeach(int[] array, int search_value)
{   
    int lower_bound = 0;
    int upper_bound = array.Length - 1;
    while (lower_bound <= upper_bound)
    {
        int midpoint = (upper_bound + lower_bound) / 2;
        int value_at_midpoint = array[midpoint];
        if (value_at_midpoint == search_value)
            return midpoint;
        else if (search_value < value_at_midpoint)
            upper_bound = midpoint - 1;
        else if (search_value > value_at_midpoint)
            lower_bound = midpoint + 1;
    }
    return -1;
}

int[] my_array = new int[]{2, 3, 5, 9, 23, 103};
WriteLine(BinarySeach(my_array, 9));