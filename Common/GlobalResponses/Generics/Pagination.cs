namespace Common.GlobalResponses.Generics;

public class Pagination<T>
{
    public List<T> Items { get; set; }=new();
    public int TotalCount { get; set; }
   
    public Pagination(List<T> items,int count)
    {
        Items = items;  
        TotalCount = count; 
            
    }
    public Pagination()
    {
        
    }
}
