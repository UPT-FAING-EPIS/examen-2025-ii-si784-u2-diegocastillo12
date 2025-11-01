using DocumentConverter.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/", () => Results.Content(@"
<!DOCTYPE html>
<html>
<head>
    <title>Document Converter</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            max-width: 800px;
            margin: 50px auto;
            padding: 20px;
            background-color: #f5f5f5;
        }
        .container {
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        h1 {
            color: #333;
            text-align: center;
        }
        .form-group {
            margin-bottom: 20px;
        }
        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }
        textarea, select {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
            font-size: 14px;
            box-sizing: border-box;
        }
        textarea {
            min-height: 100px;
            resize: vertical;
        }
        button {
            background-color: #4CAF50;
            color: white;
            padding: 12px 30px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            width: 100%;
        }
        button:hover {
            background-color: #45a049;
        }
        #result {
            margin-top: 20px;
            padding: 15px;
            background-color: #e8f5e9;
            border-radius: 5px;
            display: none;
        }
        #result.error {
            background-color: #ffebee;
        }
        #convertedContent {
            margin-top: 10px;
            padding: 10px;
            background-color: white;
            border: 1px solid #ddd;
            border-radius: 5px;
            word-wrap: break-word;
        }
    </style>
</head>
<body>
    <div class='container'>
        <h1>Document Converter</h1>
        <div class='form-group'>
            <label for='content'>Document Content:</label>
            <textarea id='content' placeholder='Enter your document content here...'></textarea>
        </div>
        <div class='form-group'>
            <label for='format'>Target Format:</label>
            <select id='format'>
                <option value='docx'>DOCX</option>
                <option value='pdf'>PDF</option>
                <option value='txt'>TXT</option>
            </select>
        </div>
        <button id='convertBtn' onclick='convertDocument()'>Convert Document</button>
        <div id='result'>
            <h3>Conversion Result:</h3>
            <div id='convertedContent'></div>
        </div>
    </div>
    <script>
        async function convertDocument() {
            const content = document.getElementById('content').value;
            const format = document.getElementById('format').value;
            const resultDiv = document.getElementById('result');
            const convertedContentDiv = document.getElementById('convertedContent');
            
            try {
                const response = await fetch('/api/convert', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ content, format })
                });
                
                const data = await response.json();
                
                if (response.ok) {
                    convertedContentDiv.textContent = data.convertedContent;
                    resultDiv.className = '';
                    resultDiv.style.display = 'block';
                } else {
                    convertedContentDiv.textContent = 'Error: ' + data.error;
                    resultDiv.className = 'error';
                    resultDiv.style.display = 'block';
                }
            } catch (error) {
                convertedContentDiv.textContent = 'Error: ' + error.message;
                resultDiv.className = 'error';
                resultDiv.style.display = 'block';
            }
        }
    </script>
</body>
</html>
", "text/html"));

app.MapPost("/api/convert", (ConversionRequest request) =>
{
    try
    {
        var converter = DocumentConverterFactory.CreateDocumentConverter(request.Format);
        var result = converter.Convert(request.Content);
        return Results.Ok(new { convertedContent = result, targetExtension = converter.TargetExtension });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

app.Run();

record ConversionRequest(string Content, string Format);
