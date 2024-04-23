--
-- Table structure for table `apiitem`
--

DROP TABLE IF EXISTS `apiitem`;

DROP TABLE IF EXISTS apiitem;
CREATE TABLE apiitem  (
  apiitem_id int UNSIGNED NOT NULL AUTO_INCREMENT,
  char_id int UNSIGNED NOT NULL,
  item_id int UNSIGNED NOT NULL,
  qty smallint UNSIGNED NOT NULL DEFAULT 1,
  request_time datetime NOT NULL,
  process_time datetime NULL DEFAULT NULL,
  status tinyint NOT NULL DEFAULT 0,
  PRIMARY KEY (apiitem_id) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = FIXED;