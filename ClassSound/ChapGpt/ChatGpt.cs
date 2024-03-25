using OpenAI_API;
using OpenAI_API.Completions;

namespace ClassSound.ChapGpt;

internal class ChatGpt
{
    public async Task<string> Execute(string bandName)
    {
        var openAiApiKey = ""; //YOUR OPENAI KEY HERE IF YOU WANT TO USE CHATGPT INTERACTION
        var chatGptResponse = "";

        if (!string.IsNullOrEmpty(openAiApiKey))
        {
            APIAuthentication aPIAuthentication = new(openAiApiKey);
            OpenAIAPI openAiApi = new(aPIAuthentication);

            try
            {
                string prompt = $"Resume the band {bandName} in one paragraph and informally";
                var completionRequest = new CompletionRequest
                {
                    Prompt = prompt,
                    MaxTokens = 50
                };

                var completionResult = await openAiApi.Completions.CreateCompletionAsync(completionRequest);
                chatGptResponse = completionResult.Completions[0].Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        return chatGptResponse;
    }
}
