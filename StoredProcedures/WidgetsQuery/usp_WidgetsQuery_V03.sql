------------------------------------------------------------------------------------------------------------------------
--usp_WidgetsQuery
--06/10/2025 - NPaxton - Created Initial stored procedure 
--06/10/2025 - NPaxton - Added Shape to query return
--06/10/2025 - NPaxton - Added IsActive where clause
--06/11/2025 - NPaxton - Added Id to query return
------------------------------------------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION usp_WidgetsQuery()
RETURNS TABLE (Id uuid, Color text, Dimensions text, Shape text) AS $$
BEGIN
    RETURN QUERY
    SELECT "Id", "Color", "Dimensions", "Shape"
    FROM "Widgets"
    WHERE "IsActive" = TRUE;
END;
$$ LANGUAGE plpgsql;