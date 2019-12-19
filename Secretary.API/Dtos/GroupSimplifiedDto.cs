using Secretary.API.Model;

namespace Secretary.API.Dtos
{
  public class GroupSimplifiedDto
  {
    public long Id { get; set; }
    public string Local { get; set; }
    public CongregationSimplifiedDto Congregacao { get; set; }
    public long CongregacaoId { get; set; }
  }
}