// See https://aka.ms/new-console-template for more information
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using ClassLibraryES.Managers;
using ClassLibraryES.semantic_es;
SemanticDB r = new(true);
//Relation r = new("test");
/*var options = new JsonSerializerOptions
{
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
    WriteIndented = true
};
string json = JsonSerializer.Serialize(r, options);
Console.WriteLine(json);
SemanticDB? restore = JsonSerializer.Deserialize<SemanticDB>(json);
//Relation? restore = JsonSerializer.Deserialize<Relation>(json);
restore?.Open();
Console.WriteLine(restore);
*/

;
KnowledgeBaseManager.Get().Load(Directory.GetCurrentDirectory()+"\\Экспертные системы\\"+"de.es");
KnowledgeBaseManager.Get();