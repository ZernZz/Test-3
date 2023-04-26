using System;
class MainClass {
  static void Main(string[] args) {
    Console.Write("Enter the number of booths open for rent (n): ");
    int n = int.Parse(Console.ReadLine());
    bool[] booths = new bool[n];
    while (true) {
      Console.Write("Enter booth number(s) to reserve (separate with a space): ");
      int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
      int start = Math.Min(input[0], input[1]) - 1;
      int end = Math.Max(input[0], input[1]) - 1;
      bool conflict = false;
      if (start < 0) {
        if (end < 0) break;
        if (booths[0]) Console.WriteLine("The booth is reserved.");
        else { booths[0] = true; Console.WriteLine("The entrance can't be reserved."); }
      }
      else if (start == end) {
        if (booths[start]) Console.WriteLine("The booth is reserved.");
        else { booths[start] = true; Console.WriteLine("Reservation successful."); }
      }
      else if (end - start == 1) {
        for (int i = start; i <= end; i++) {
          if (booths[i]) { Console.WriteLine("The booth is reserved."); conflict = true; break; }
        }
        if (!conflict) {
          for (int i = start; i <= end; i++) { booths[i] = true; }
          Console.WriteLine("Reservation successful.");
        }
      }
      else Console.WriteLine("The entrance can't be reserved.");
      Console.WriteLine("Status: " + string.Join(" ", Array.ConvertAll(booths, x => x ? "X" : "_")));
      if (Array.IndexOf(booths, false) == -1) { Console.WriteLine("All booths are reserved."); break; }
    }
  }
}