using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MedicalApp21.Services
{
    public class UploadFileMPUHighLevelAPI
    {
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.EUCentral1;
        private static IAmazonS3 s3Client;

        public static async Task UploadFileAsync(string _filePath, string _bucketName, string _keyName)
        {
            s3Client = new AmazonS3Client("", "",bucketRegion);
            try
            {
                var fileTransferUtility = new TransferUtility(s3Client);

                // Option 2. Specify object key name explicitly.
                await fileTransferUtility.UploadAsync(_filePath, _bucketName, _keyName);
               //CrossToastPopUp.Current.ShowToastMessage("Upload Completed!");

            }
            catch (AmazonS3Exception e)
            {
                CrossToastPopUp.Current.ShowToastMessage($"Error encountered on server. Message:'{e.Message}' when writing an object");
            }
            catch (Exception e)
            {
                CrossToastPopUp.Current.ShowToastMessage($"Unknown encountered on server. Message:'{e.Message}' when writing an object");
            }
        }
    }
}
