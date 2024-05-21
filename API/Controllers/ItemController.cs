using Common.ApiException;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : BaseController
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSearchableItems(string itemName)
        {
            try
            {
                var response = await _itemService.GetDropdownItemsAsync(itemName);
                return Ok(response);
            }
            catch (ApiException aexp)
            {
                return HandleApiException(aexp);
            }
            catch (Exception ex)
            {
                return HandleApiException(ex);
            }
        }

        [HttpPost("Save")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SaveItems(Item item)
        {
            try
            {
                _itemService.Save(item);
                    return Ok();
            }
            catch (ApiException aexp)
            {

               return HandleApiException(aexp);
            }
            catch(Exception ex)
            {
                return HandleApiException(ex);
            }
        }
        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var item = await _itemService.GetById(id);
                return Ok(item);
            }
            catch (ApiException aexp)
            {

                return HandleApiException(aexp);
            }
            catch (Exception ex)
            {
                return HandleApiException(ex);
            }

        }
        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  IActionResult Delete(int id)
        {
            try
            {
                _itemService.Delete(id);
                return Ok();
            }
            catch (ApiException aexp)
            {

                return HandleApiException(aexp);
            }
            catch (Exception ex)
            {
                return HandleApiException(ex);
            }

        }
    }
}