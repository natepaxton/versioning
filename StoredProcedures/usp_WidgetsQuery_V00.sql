/*======================================================================================================================
usp_WidgetsQuery
06/10/2025 - NPaxton - Created Initial stored procedure 
======================================================================================================================*/

CREATE OR REPLACE FUNCTION usp_WidgetsQuery()
RETURNS TABLE (Color text, Dimensions text) AS $$
BEGIN
    RETURN QUERY
    SELECT "Color", "Dimensions"
    FROM "Widgets";
END;
$$ LANGUAGE plpgsql;