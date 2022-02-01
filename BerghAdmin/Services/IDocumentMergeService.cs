namespace BerghAdmin.Services;

public interface IDocumentMergeService
{
    List<Document> GetMergeTemplates();
    Document? GetMergeTemplateById(int id);
    Document GetMergeTemplateByName(string name);
    void SaveMergeTemplate(Document mergeTemplate);
    void DeleteMergeTemplate(int id);
    Stream Merge(Document template, Dictionary<string, string> mergeFields);
    IEnumerable<string> GetMergeFieldsFor(Document document);
}