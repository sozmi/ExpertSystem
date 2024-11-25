using ClassLibraryES.semantic_es;
using Newtonsoft.Json;
SemanticDB r = new(true);

string json = JsonConvert.SerializeObject(r, Formatting.Indented);
Console.WriteLine(json);
SemanticDB? restore = JsonConvert.DeserializeObject<SemanticDB>(json);
restore?.Open();
Console.WriteLine(restore);

;
/*KnowledgeBaseManager.Get().Create("def");
KnowledgeBaseManager.Get().Load(Directory.GetCurrentDirectory()+"\\Экспертные системы\\"+"def.es");
KnowledgeBaseManager.Get();*/