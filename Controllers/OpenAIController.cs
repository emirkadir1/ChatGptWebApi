using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using OpenAI.GPT3.ObjectModels.ResponseModels.ImageResponseModel;

namespace ChatGptWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        readonly IOpenAIService _openAIService;

        public OpenAIController(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }
        [HttpPost("askquestion")]
        public async Task<string> AskQuestion(string question)
        {
         CompletionCreateResponse result = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = question,
                MaxTokens=500
            },Models.TextDavinciV3 );
            return result.Choices[0].Text;
        }
        [HttpPost("drawimage")]
        public async Task<IEnumerable<string>> DrawImage(string question)
        {
        ImageCreateResponse result = await _openAIService.Image.CreateImage(new ImageCreateRequest()
            {
                Prompt = question,
                N = 1,
                Size = "1024x1024",
                ResponseFormat= StaticValues.ImageStatics.ResponseFormat.Url,
                User = "test"
            });
             return result.Results.Select(r=>r.Url);
        }
    }
}
