using SimCorp_Task;

//var lend = new LendMoney(Convert.ToDateTime("01/01/2021"), 1200, 12, 2);
////var lend = new LendMoney(DateTime.Today, 3000, 15, 3);
////double year = 1.0 / 6;
////var lend = new LendMoney(Convert.ToDateTime("01/01/2021"), 1200, 12, year);
////lend.ShowPayments();

////var interestedDate = Convert.ToDateTime("01/01/2021");

//lend.ShowPayments(DateTime.Now);
//Console.WriteLine(lend.SumOfInterestPayments(DateTime.Now).ToString("C"));
//Console.WriteLine(lend.SumOfInterestPayments().ToString("C"));

var lend = new LendMoney(DateTime.Today, 3000, 15, 3);
var interestedDate = Convert.ToDateTime("05/15/2022");
//lend.ShowPayments(interestedDate);
Console.WriteLine(lend.SumOfInterestPayments(interestedDate).ToString("C"));
