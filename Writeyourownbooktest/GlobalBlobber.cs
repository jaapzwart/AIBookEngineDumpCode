using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;

namespace Writeyourownbooktest
{
    public class GlobalBlobber
    {
        public static string readFileFromBlob(string fileName, string blobber)
        {
            try
            {
                // Initialise client in a different place if you like
                string connS = Secrets.cloudStorageConnString;
                CloudStorageAccount account = CloudStorageAccount.Parse(connS);
                var blobClient = account.CreateCloudBlobClient();

                var blobContainer = blobClient.GetContainerReference(blobber);
                blobContainer.CreateIfNotExistsAsync();

                CloudBlockBlob blob = blobContainer.GetBlockBlobReference($"{fileName}");
                string contents = blob.DownloadTextAsync().Result;

                return contents;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        public static async Task<string[]> ReadLinesFromBlobAsync(string blobConnectionString, string containerName, string blobName)
        {
            try
            {
                var blobClient = new BlobClient(blobConnectionString, containerName, blobName);

                if (await blobClient.ExistsAsync())
                {
                    var downloadInfo = await blobClient.DownloadAsync();
                    var reader = new StreamReader(downloadInfo.Value.Content, Encoding.UTF8);
                    var content = await reader.ReadToEndAsync();
                    return content.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                }

                return Array.Empty<string>();
            }
            catch (Exception ex)
            {
                return new[] { "Error:" + ex.Message };
            }
        }
        public static async Task<string> WritePdfToBlobAsync(byte[] pdfBytes, string fileName, string containername)
        {
            try
            {
                string connS = Secrets.cloudStorageConnString;
                var account = CloudStorageAccount.Parse(connS);
                var blobClient = account.CreateCloudBlobClient();

                var blobContainer = blobClient.GetContainerReference(containername);
                await blobContainer.CreateIfNotExistsAsync();

                CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(fileName);
                using (var stream = new MemoryStream(pdfBytes))
                {
                    await blockBlob.UploadFromStreamAsync(stream);
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static async Task<List<string>> GetTxtFileNamesAsync(string _connectionString, string _containerName)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);

            var txtFiles = new List<string>();

            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                if (blobItem.Name.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    txtFiles.Add(blobItem.Name);
                }
            }

            return txtFiles;
        }
        public static async Task<string> GetFileContentAsync(string blobName, string _connectionString, string _containerName)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            using var stream = new MemoryStream();
            await blobClient.DownloadToAsync(stream);
            stream.Position = 0;

            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
        public static async Task DeleteBlobAsync(string connectionString, string containerName, string blobName)
        {
            var containerClient = new BlobContainerClient(connectionString, containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            await blobClient.DeleteIfExistsAsync();
        }
    }
}
