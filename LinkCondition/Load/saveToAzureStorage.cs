using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;

namespace LinkCondition.Load
{
    public static class saveToAzureStorage
    {
        public static bool saveToAzureBlob(this string JSON, string connectionString, string storagecontainer)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(storagecontainer);
            CloudBlockBlob blob = container.GetBlockBlobReference(utility.getTimeStamp()); // Get time stamp used for naming the blob in blob storage
            var uploadtask = blob.UploadTextAsync(JSON);
            uploadtask.Wait();
            return uploadtask.IsCompleted;
        }

        public static bool saveToAzureStorageQueue(this string JSON, string connectionString, string queuename)
        {
            // todo: add code to check and handle 64KB message limit for queues
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(queuename);
            CloudQueueMessage message = new CloudQueueMessage(JSON);
            var uploadtask = queue.AddMessageAsync(message);
            uploadtask.Wait();
            return uploadtask.IsCompleted;
        }

        public static string createStorageConnectionString(string storageAccountName, string azureStorageAccessKey)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=" + storageAccountName +
                                      ";AccountKey=" + azureStorageAccessKey;
            return connectionString;
        }
    }
}
