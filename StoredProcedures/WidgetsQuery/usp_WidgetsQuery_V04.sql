------------------------------------------------------------------------------------------------------------------------
--usp_WidgetsQuery
--06/10/2025 - NPaxton - Created Initial stored procedure 
--06/10/2025 - NPaxton - Added Shape to query return
--06/10/2025 - NPaxton - Added IsActive where clause
--06/11/2025 - NPaxton - Added Id to query return
--06/11/2025 - NPaxton - Removed Id from query    
------------------------------------------------------------------------------------------------------------------------

DROP FUNCTION IF EXISTS usp_WidgetsQuery();
CREATE OR REPLACE FUNCTION usp_WidgetsQuery()
RETURNS TABLE (Color text, Dimensions text, Shape text) AS $$
BEGIN
    RETURN QUERY
    SELECT "Color", "Dimensions", "Shape"
    FROM "Widgets"
    WHERE "IsActive" = TRUE;
END;
$$ LANGUAGE plpgsql;