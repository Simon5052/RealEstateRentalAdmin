$(document).ready(function () {
    $.validator.setDefaults({
        ignore: [],
        // any other default options and/or rules
    });
    $("#form").validate({
        rules: {
            PropertyName: {
                required: true,
                minlength: 3,
            },
            PropertyTypeId: 'required',
            RegionId: 'required',
            LocationId: 'required',
            Rooms: {
                required: true,
                digits: true,

            },
            Space: {
                required: true,
                digits: true,

            },
            Cost: {
                required: true,
                digits: true,

            },
        }
    })

    $("#Region").width("100%").kendoDropDownList({
        highlightFirst: true,
        suggest: true,
        dataSource: {
            transport: {
                read: {
                    url: "/api/RegionApi/GetAllRegions"
                }
            }
        },
        index: 0,
        dataTextField: 'RegionName',
        dataValueField: 'RegionUuid',
        optionLabel: '--Select Region--',
        change: UpdateLocation

    });

    var regionUuid = $("#Region").val();
    RenderLocations(regionUuid);


});

function UpdateLocation() {
    var regionUuid = $("#Region").val();
    console.log(regionUuid);
    RenderLocations(regionUuid);
}

function RenderLocations(regionUuid) {
    if (!regionUuid)
        regionUuid = "00000000-0000-0000-0000-000000000000";

    $("#LocationId").width("100%").kendoDropDownList({
        highlightFirst: true,
        suggest: true,
        dataSource: {
            transport: {
                read: {
                    url: '/api/LocationApi/PerRegion?regionUuid=' + regionUuid
                }
            }
        },
        index: 0,
        dataTextField: 'Address',
        dataValueField: 'LocationUuid',
        optionLabel: '--Select Location--'
    });
}



$("#PropertyTypeId").width("100%").kendoDropDownList({
    highlightFirst: true,
    suggest: true,
    dataSource: {
        transport: {
            read: {
                url: "/api/PropertyTypeApi/AllPropertyType"
            }
        }
    },
    index: 0,
    dataTextField: 'PropertTypeName',
    dataValueField: 'PropertyTypeUuid',
    optionLabel: '--Select Property Type--',

});

$("#GalleryTypeId").width("100%").kendoDropDownList({
    highlightFirst: true,
    suggest: true,
    dataSource: {
        transport: {
            read: {
                url: "/api/GalleryTypeApi/AllGalleryType"
            }
        }
    },
    index: 0,
    dataTextField: 'Name',
    dataValueField: 'GalleryTypeUuid',
    optionLabel: '--Select Property Type--',

});