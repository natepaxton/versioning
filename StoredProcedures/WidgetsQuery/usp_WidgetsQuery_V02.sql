/*======================================================================================================================
usp_WidgetsQuery
06/10/2025 - NPaxton - Created Initial stored procedure 
06/10/2025 - NPaxton - Added Shape to query return
06/10/2025 - NPaxton - Added IsActive where clause
======================================================================================================================*/

CREATE OR REPLACE FUNCTION usp_WidgetsQuery()
RETURNS TABLE (Color text, Dimensions text) AS $$
BEGIN
    RETURN QUERY
    SELECT "Color", "Dimensions", "Shape"
    FROM "Widgets"
    WHERE "IsActive" = TRUE;
END;
$$ LANGUAGE plpgsql;