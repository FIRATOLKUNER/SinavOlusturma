namespace SinavOlusturma.Model { }

public class Questions
{
    public int Id { get; set; }
    public string Date { get; set; }
    public string Post_Title { get; set; }
    public string Post_Content { get; set; }
    public string Question1 { get; set; }
    public string Question1_A { get; set; }
    public string Question1_B { get; set; }
    public string Question1_C { get; set; }
    public string Question1_D { get; set; }
    public string Question1_Answer { get; set; }
    public string Question2 { get; set; }
    public string Question2_A { get; set; }
    public string Question2_B { get; set; }
    public string Question2_C { get; set; }
    public string Question2_D { get; set; }
    public string Question2_Answer { get; set; }
    public string Question3 { get; set; }
    public string Question3_A { get; set; }
    public string Question3_B { get; set; }
    public string Question3_C { get; set; }
    public string Question3_D { get; set; }
    public string Question3_Answer { get; set; }
    public string Question4 { get; set; }
    public string Question4_A { get; set; }
    public string Question4_B { get; set; }
    public string Question4_C { get; set; }
    public string Question4_D { get; set; }
    public string Question4_Answer { get; set; }
    public string IsComplete { get; set; }
}

public class Users
{
    public int Id { get; set; }
    public string User_Name { get; set; }
    public string User_Password { get; set; }
}
